// Code generated from CsvHelper, DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json; // 用于处理 CSV 中的 JSON 字符串 (如果需要)
using Newtonsoft.Json.Linq; // 用于 JArray, JObject (如果需要)
using UnityEngine; // 用于 Debug.Log

public static class CsvHelper
{
    // CSV 的数组元素分隔符
    private const char ArrayElementSeparator = ','; 

    /// <summary>
    /// 将 CSV 内容解析为对象列表。
    /// </summary>
    /// <typeparam name="T">目标 C# 对象的类型。</typeparam>
    /// <param name="csvContent">CSV 文件的内容字符串。</param>
    /// <returns>解析后的对象列表。</returns>
    public static List<T> ParseCsvContent<T>(string csvContent) where T : new()
    {
        if (string.IsNullOrEmpty(csvContent))
        {
            Debug.LogWarning("CsvHelper: CSV content is null or empty.");
            return new List<T>();
        }

        List<T> dataList = new List<T>();
        
        using (var reader = new StringReader(csvContent))
        {
            string headerLine = reader.ReadLine();
            if (string.IsNullOrEmpty(headerLine))
            {
                Debug.LogError("CsvHelper: CSV file is empty or has no header.");
                return dataList;
            }

            // 分割列头，建立列名到索引的映射 (忽略大小写)
            var headers = headerLine.Split(',').Select(h => h.Trim()).ToArray();
            var headerMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i < headers.Length; i++)
            {
                if (!headerMap.ContainsKey(headers[i]))
                {
                    headerMap.Add(headers[i], i);
                }
            }

            var propertyInfos = typeof(T).GetProperties(); 

            string dataLine;
            int lineNumber = 1; 
            while ((dataLine = reader.ReadLine()) != null)
            {
                lineNumber++;
                if (string.IsNullOrWhiteSpace(dataLine)) continue;

                try
                {
                    // --- 简单的逗号分割 ---
                    // 注意：如果您的 CSV 字段本身包含逗号，需要更健壮的 CSV 解析器（如 CSV Helper 库）
                    var values = dataLine.Split(','); 
                    T instance = new T(); 

                    foreach (var prop in propertyInfos)
                    {
                        // --- 列名匹配逻辑 ---
                        int columnIndex = -1; 
                        string targetColumnName = prop.Name; // 直接使用 C# 属性名 (PascalCase)

                        // --- 匹配 CSV 列头 ---
                        // 尝试用 C# 属性名（PascalCase）去匹配 CSV 列头（忽略大小写）
                        // 例如: C# 的 MaxSpeed 匹配 CSV 的 max_speed (如果 headerMap 包含 max_speed)
                        // 由于 headerMap 使用 StringComparer.OrdinalIgnoreCase，直接用 prop.Name (如 "MaxSpeed")
                        // 就能匹配到 CSV 中的 "max_speed" 或 "MaxSpeed"
                        if (headerMap.TryGetValue(targetColumnName, out columnIndex))
                        {
                            // 匹配成功
                        }
                        else
                        {
                            // 如果直接用 PascalCase 属性名匹配（忽略大小写）失败，
                            // 并且您确定 CSV 列头是 snake_case (如 max_speed)，
                            // 您需要在这里加入 snake_case 转换逻辑。
                            // 例如，将 prop.Name ("MaxSpeed") 转换为 "max_speed" 再查找。
                            // 但根据您的最新要求：“保持csv里的字段和C#的数据类字段一致就可以了”，
                            // 这意味着您的 CSV 列头可能就是 "Id", "Name", "Speed", "MaxSpeed", "Items1" 等。
                            // 如果是这样，那么只进行忽略大小写的匹配就足够了。
                            // 如果 CSV 列头是 "max_speed" 并且 C# 属性是 "MaxSpeed"，
                            // 那么您需要修改 prop.Name 的查找方式，或者使用特性。
                            // 为了满足“保持一致”的要求，我们假定 CSV 列头能通过 prop.Name (忽略大小写) 匹配。
                            // 例如：C# 的 MaxSpeed 匹配 CSV 的 max_speed （通过 OrdinalIgnoreCase）
                            // 如果 CSV 列头是 max_speed，并且 C# 属性是 MaxSpeed，那么直接用 prop.Name (MaxSpeed) 去匹配 headerMap (大小写不敏感) 会成功！
                            
                            // 如果您的 CSV 列头是 "items_1" 而属性是 "Items1"，忽略大小写匹配也能成功。
                            // 如果您希望更精确控制，例如将 "items_1" 映射到 "Items1"，那么需要特性或更复杂的映射。
                            
                            // --- 简化匹配逻辑 ---
                            // 假设我们只需要属性名和列头名（忽略大小写）匹配即可
                            // 如果 CSV 列头是 "max_speed", C# 是 "MaxSpeed", 它们在忽略大小写下匹配
                            // 如果 CSV 列头是 "items_1", C# 是 "Items1", 它们在忽略大小写下匹配
                            // 所以，只需要 TryGetValue(prop.Name, out columnIndex) 就够了。
                            
                            // Debug.LogWarning($"CsvHelper: Column for property '{prop.Name}' not found in CSV headers (case-insensitive).");
                            continue; // 匹配失败，跳过此属性
                        }

                        // --- 检查是否找到了列 ---
                        if (columnIndex >= 0 && columnIndex < values.Length)
                        {
                            string cellValue = values[columnIndex].Trim();
                            object convertedValue = null;

                            Type propType = prop.PropertyType;
                            Type baseElementType = null; 

                            bool isArray = propType.IsArray;
                            bool isList = propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(List<>);

                            // --- 处理数组和 List 的转换 ---
                            if ((isArray || isList) && !string.IsNullOrEmpty(cellValue))
                            {
                                if (isArray) baseElementType = propType.GetElementType();
                                else if (isList) baseElementType = propType.GetGenericArguments()[0];

                                if (baseElementType != null)
                                {
                                    // !!! 关键：使用正确的数组元素分隔符 !!!
                                    // 您提供的 CSV 数据使用分号 ';' 作为数组元素分隔符
                                    var elements = cellValue.Split(ArrayElementSeparator, StringSplitOptions.RemoveEmptyEntries);
                                    
                                    try
                                    {
                                        if (isList)
                                        {
                                            var genericListType = typeof(List<>).MakeGenericType(baseElementType);
                                            var listInstance = Activator.CreateInstance(genericListType); 
                                            var addMethod = genericListType.GetMethod("Add");

                                            for (int i = 0; i < elements.Length; i++)
                                            {
                                                object elementValue = ConvertStringValue(elements[i], baseElementType);
                                                if (elementValue != null)
                                                {
                                                    addMethod.Invoke(listInstance, new object[] { elementValue });
                                                }
                                            }
                                            convertedValue = listInstance;
                                        }
                                        else if (isArray)
                                        {
                                            var array = Array.CreateInstance(baseElementType, elements.Length);
                                            for (int i = 0; i < elements.Length; i++)
                                            {
                                                object elementValue = ConvertStringValue(elements[i], baseElementType);
                                                if (elementValue != null)
                                                {
                                                    // 使用 Convert.ChangeType 来尝试安全的类型转换
                                                    array.SetValue(Convert.ChangeType(elementValue, baseElementType), i);
                                                }
                                                else
                                                {
                                                    // 如果转换失败，为数组元素设置默认值
                                                    array.SetValue(Activator.CreateInstance(baseElementType), i);
                                                    Debug.LogWarning($"CsvHelper: Element '{elements[i]}' for array property '{prop.Name}' could not be converted to {baseElementType.Name}. Setting to default.");
                                                }
                                            }
                                            convertedValue = array;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.LogError($"CsvHelper: Error processing array elements for property '{prop.Name}'. Error: {ex.Message}");
                                        convertedValue = null; 
                                    }
                                }
                            }
                            else if (!isArray && !isList) // --- 基本类型 ---
                            {
                                convertedValue = ConvertStringValue(cellValue, propType);
                            }
                            else if ((isArray || isList) && string.IsNullOrEmpty(cellValue))
                            {
                                // --- 单元格为空，但属性是数组/列表 ---
                                if (isList) convertedValue = Activator.CreateInstance(typeof(List<>).MakeGenericType(baseElementType));
                                else if (isArray) convertedValue = Array.CreateInstance(baseElementType, 0);
                            }
                            
                            // --- 赋值 ---
                            if (convertedValue != null)
                            {
                                prop.SetValue(instance, convertedValue);
                            }
                            else if (propType.IsValueType) // 如果属性是值类型且转换失败，设置为默认值
                            {
                                prop.SetValue(instance, Activator.CreateInstance(propType));
                            }
                        }
                    }
                    dataList.Add(instance);
                }
                catch (Exception ex)
                {
                    Debug.LogError($"CsvHelper: Error processing row {lineNumber} for type {typeof(T).Name}. Error: {ex.Message}");
                }
            }
        }
        return dataList;
    }

    /// <summary>
    /// 将 CSV 内容解析为字典。
    /// </summary>
    /// <typeparam name="K">字典键的类型。</typeparam>
    /// <typeparam name="T">字典值的类型。</typeparam>
    /// <param name="csvContent">CSV 文件的内容字符串。</param>
    /// <param name="keyColumnName">用于生成字典键的 CSV 列名。</param>
    /// <returns>解析后的字典。</returns>
    public static Dictionary<K, T> ParseDictionary<K, T>(string csvContent, string keyColumnName = "id") where T : new() where K : struct
    {
        if (string.IsNullOrEmpty(csvContent))
        {
            Debug.LogWarning("CsvHelper.ParseCsvToDictionary: CSV content is null or empty.");
            return new Dictionary<K, T>();
        }

        var dataList = ParseCsvContent<T>(csvContent); // 首先将 CSV 解析为 List<T>
        var dataMap = new Dictionary<K, T>();

        if (dataList == null || !dataList.Any())
        {
            return dataMap;
        }

        // 找到用于键的属性
        var keyProperty = typeof(T).GetProperty(keyColumnName); // 直接用属性名匹配
        if (keyProperty == null)
        {
            // 如果直接按属性名找不到，尝试根据特性或 snake_case 查找
            // 这依赖于您的 C# 类定义和 CSV 列名格式
            keyProperty = typeof(T).GetProperties()
                                   .FirstOrDefault(p => 
                                       p.Name.Equals(keyColumnName, StringComparison.OrdinalIgnoreCase) || // PascalCase 属性名匹配
                                       ToSnakeCase(p.Name).Equals(keyColumnName, StringComparison.OrdinalIgnoreCase) || // snake_case 属性名匹配
                                       p.Name.ToLower().Equals(keyColumnName, StringComparison.OrdinalIgnoreCase) // camelCase 属性名匹配 (简单处理)
                                   );
            
            if (keyProperty == null)
            {
                Debug.LogError($"CsvHelper: Key property '{keyColumnName}' not found in type {typeof(T).Name}.");
                return dataMap;
            }
        }
        
        Type keyPropType = keyProperty.PropertyType;

        foreach (var item in dataList)
        {
            try
            {
                object keyValue = keyProperty.GetValue(item);
                
                object convertedKey = null;
                if (keyValue != null)
                {
                    convertedKey = Convert.ChangeType(keyValue, typeof(K));
                }
                else if (typeof(K).IsValueType) // 如果键是值类型且 keyValue 为 null
                {
                    convertedKey = Activator.CreateInstance(typeof(K)); // 设置为默认值
                }
                
                if (convertedKey != null)
                {
                    if (!dataMap.ContainsKey((K)convertedKey))
                    {
                        dataMap.Add((K)convertedKey, item);
                    }
                    else
                    {
                        Debug.LogWarning($"CsvHelper: Duplicate key '{convertedKey}' found for property '{keyColumnName}'. Skipping duplicate entry.");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"CsvHelper: Error processing key for item with property '{keyProperty.Name}'. Error: {ex.Message}");
            }
        }
        return dataMap;
    }

    // --- 辅助方法：将字符串值转换为目标类型 ---
    private static object ConvertStringValue(string strValue, Type targetType)
    {
        if (targetType == typeof(string)) return strValue;
        
        strValue = strValue.Trim();

        if (string.IsNullOrEmpty(strValue))
        {
            return targetType.IsValueType ? Activator.CreateInstance(targetType) : null;
        }

        try
        {
            // --- 基本类型转换 ---
            if (targetType == typeof(int)) return int.Parse(strValue);
            if (targetType == typeof(long)) return long.Parse(strValue);
            if (targetType == typeof(short)) return short.Parse(strValue);
            if (targetType == typeof(byte)) return byte.Parse(strValue);
            if (targetType == typeof(float)) return float.Parse(strValue);
            if (targetType == typeof(double)) return double.Parse(strValue);
            if (targetType == typeof(decimal)) return decimal.Parse(strValue);
            if (targetType == typeof(bool)) return bool.Parse(strValue);
            if (targetType == typeof(char)) return strValue.Length > 0 ? (object)strValue[0] : '\0';
            
            // --- JSON 字符串处理 ---
            if (targetType == typeof(JArray) && strValue.StartsWith("[") && strValue.EndsWith("]"))
            {
                try { return JArray.Parse(strValue); }
                catch (JsonReaderException jre) { Debug.LogError($"CsvHelper: Failed to parse JSON array for '{strValue}'. Error: {jre.Message}"); return null;}
                catch (Exception ex) { Debug.LogError($"CsvHelper: Error parsing JSON array '{strValue}'. Error: {ex.Message}"); return null; }
            }
            if (targetType == typeof(JObject) && strValue.StartsWith("{") && strValue.EndsWith("}"))
            {
                try { return JObject.Parse(strValue); }
                catch (JsonReaderException jre) { Debug.LogError($"CsvHelper: Failed to parse JSON object for '{strValue}'. Error: {jre.Message}"); return null;}
                catch (Exception ex) { Debug.LogError($"CsvHelper: Error parsing JSON object '{strValue}'. Error: {ex.Message}"); return null; }
            }
            
            Debug.LogWarning($"CsvHelper: Unsupported conversion from string '{strValue}' to {targetType.Name}.");
            return null;
        }
        catch (FormatException fe)
        {
            Debug.LogError($"CsvHelper: Failed to convert '{strValue}' to {targetType.Name}. Format error: {fe.Message}");
            return null; 
        }
        catch (OverflowException oe)
        {
            Debug.LogError($"CsvHelper: Failed to convert '{strValue}' to {targetType.Name}. Overflow error: {oe.Message}");
            return null;
        }
        catch (Exception ex)
        {
            Debug.LogError($"CsvHelper: Unexpected error converting '{strValue}' to {targetType.Name}. Error: {ex.Message}");
            return null;
        }
    }

    // --- 辅助方法：将 C# 属性名 (PascalCase) 转换为 CSV 列头名 (snake_case) ---
    private static string ToSnakeCase(string pascalCaseString)
    {
        if (string.IsNullOrEmpty(pascalCaseString)) return string.Empty;
        
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(char.ToLowerInvariant(pascalCaseString[0])); 

        for (int i = 1; i < pascalCaseString.Length; i++)
        {
            char c = pascalCaseString[i];
            if (char.IsUpper(c))
            {
                sb.Append('_'); 
                sb.Append(char.ToLowerInvariant(c)); 
            }
            else
            {
                sb.Append(c); 
            }
        }
        return sb.ToString();
    }
}
