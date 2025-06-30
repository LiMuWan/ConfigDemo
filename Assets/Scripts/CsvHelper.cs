using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using JArray = Newtonsoft.Json.Linq.JArray;
using JObject = Newtonsoft.Json.Linq.JObject;
namespace Engine
{
    /// <summary>
    /// Helper class for parsing CSV data into C# objects
    /// </summary>
    public static class CsvHelper
    {
        private const char ArrayElementSeparator = ',';
        private const string DefaultKeyColumn = "id";
        /// <summary>
        /// Parses CSV content into a list of objects
        /// </summary>
        public static List<T> ParseCsvContent<T>(string csvContent) where T : new()
        {
            if (string.IsNullOrEmpty(csvContent))
            {
                Debug.LogWarning("CsvHelper: CSV content is null or empty.");
                return new List<T>();
            }
            var dataList = new List<T>();
            
            using (var reader = new StringReader(csvContent))
            {
                // Read and validate header
                var headerLine = reader.ReadLine();
                if (string.IsNullOrEmpty(headerLine))
                {
                    Debug.LogError("CsvHelper: CSV file has no header.");
                    return dataList;
                }
                // Create header mapping (case-insensitive)
                var headers = headerLine.Split(',')
                    .Select(h => h.Trim())
                    .ToArray();
                
                var headerMap = headers
                    .Select((h, i) => new { h, i })
                    .ToDictionary(x => x.h, x => x.i, StringComparer.OrdinalIgnoreCase);
                // Get properties once for better performance
                var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                int lineNumber = 1;
                // Process each data line
                string dataLine;
                while ((dataLine = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    if (string.IsNullOrWhiteSpace(dataLine)) 
                        continue;
                    try
                    {
                        var values = dataLine.Split(',');
                        var instance = new T();
                        foreach (var prop in properties)
                        {
                            if (!headerMap.TryGetValue(prop.Name, out int columnIndex))
                                continue;
                            if (columnIndex < 0 || columnIndex >= values.Length)
                                continue;
                            var cellValue = values[columnIndex].Trim();
                            var convertedValue = ConvertCellValue(cellValue, prop.PropertyType);
                            if (convertedValue != null)
                            {
                                prop.SetValue(instance, convertedValue);
                            }
                            else if (prop.PropertyType.IsValueType)
                            {
                                prop.SetValue(instance, Activator.CreateInstance(prop.PropertyType));
                            }
                        }
                        dataList.Add(instance);
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError($"CsvHelper: Error processing row {lineNumber}. Error: {ex.Message}");
                    }
                }
            }
            return dataList;
        }
        /// <summary>
        /// Parses CSV content into a dictionary with the specified key column
        /// </summary>
        public static Dictionary<K, T> ParseDictionary<K, T>(string csvContent, string keyColumnName = DefaultKeyColumn) 
            where T : new() 
            where K : struct
        {
            var dataList = ParseCsvContent<T>(csvContent);
            var result = new Dictionary<K, T>();
            if (dataList == null || dataList.Count == 0)
                return result;
            // Find key property (case-insensitive)
            var keyProperty = typeof(T).GetProperty(keyColumnName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)
                ?? typeof(T).GetProperties()
                    .FirstOrDefault(p => string.Equals(p.Name, keyColumnName, StringComparison.OrdinalIgnoreCase));
            if (keyProperty == null)
            {
                Debug.LogError($"CsvHelper: Key property '{keyColumnName}' not found in type {typeof(T).Name}.");
                return result;
            }
            // Build dictionary
            foreach (var item in dataList)
            {
                try
                {
                    var keyValue = keyProperty.GetValue(item);
                    if (keyValue == null && typeof(K).IsValueType)
                    {
                        keyValue = Activator.CreateInstance(typeof(K));
                    }
                    if (keyValue != null)
                    {
                        var convertedKey = (K)Convert.ChangeType(keyValue, typeof(K));
                        if (!result.ContainsKey(convertedKey))
                        {
                            result.Add(convertedKey, item);
                        }
                        else
                        {
                            Debug.LogWarning($"CsvHelper: Duplicate key '{convertedKey}' found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError($"CsvHelper: Error processing key. Error: {ex.Message}");
                }
            }
            return result;
        }
        /// <summary>
        /// Converts a CSV cell value to the target type
        /// </summary>
        private static object ConvertCellValue(string cellValue, Type targetType)
        {
            if (targetType == typeof(string)) 
                return cellValue;
            cellValue = cellValue?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(cellValue))
            {
                return targetType.IsValueType ? Activator.CreateInstance(targetType) : null;
            }
            try
            {
                // Handle basic types
                if (targetType == typeof(int)) return int.Parse(cellValue);
                if (targetType == typeof(long)) return long.Parse(cellValue);
                if (targetType == typeof(short)) return short.Parse(cellValue);
                if (targetType == typeof(byte)) return byte.Parse(cellValue);
                if (targetType == typeof(float)) return float.Parse(cellValue);
                if (targetType == typeof(double)) return double.Parse(cellValue);
                if (targetType == typeof(decimal)) return decimal.Parse(cellValue);
                if (targetType == typeof(bool)) return bool.Parse(cellValue);
                if (targetType == typeof(char)) return cellValue.Length > 0 ? cellValue[0] : '\0';
                // Handle arrays and lists
                if (targetType.IsArray)
                {
                    var elementType = targetType.GetElementType();
                    return ConvertArray(cellValue, elementType);
                }
                if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var elementType = targetType.GetGenericArguments()[0];
                    return ConvertList(cellValue, elementType);
                }
                // Handle JSON types
                if (targetType == typeof(JArray) && cellValue.StartsWith("[") && cellValue.EndsWith("]"))
                {
                    return JArray.Parse(cellValue);
                }
                if (targetType == typeof(JObject) && cellValue.StartsWith("{") && cellValue.EndsWith("}"))
                {
                    return JObject.Parse(cellValue);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"CsvHelper: Failed to convert '{cellValue}' to {targetType.Name}. Error: {ex.Message}");
                return null;
            }
            Debug.LogWarning($"CsvHelper: Unsupported conversion to {targetType.Name}.");
            return null;
        }
        private static Array ConvertArray(string cellValue, Type elementType)
        {
            var elements = cellValue.Split(ArrayElementSeparator, StringSplitOptions.RemoveEmptyEntries);
            var array = Array.CreateInstance(elementType, elements.Length);
            for (int i = 0; i < elements.Length; i++)
            {
                var elementValue = ConvertCellValue(elements[i], elementType);
                array.SetValue(elementValue ?? Activator.CreateInstance(elementType), i);
            }
            return array;
        }
        private static object ConvertList(string cellValue, Type elementType)
        {
            var listType = typeof(List<>).MakeGenericType(elementType);
            var list = Activator.CreateInstance(listType);
            var addMethod = listType.GetMethod("Add");
            var elements = cellValue.Split(ArrayElementSeparator, StringSplitOptions.RemoveEmptyEntries);
            foreach (var element in elements)
            {
                var elementValue = ConvertCellValue(element, elementType);
                addMethod.Invoke(list, new[] { elementValue ?? Activator.CreateInstance(elementType) });
            }
            return list;
        }
    }
}
