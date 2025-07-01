using System;
using Config;
using UnityEngine;
namespace LRR.Utilities
{
    /// <summary>
    /// Static utility for loading and managing configuration data
    /// </summary>
    public static class ConfigSystem
    {
        private static bool _isInitialized = false;
        private static Tables _tables;
        private const string JsonConfigPath = "Configs/JsonConfigs/";
        private const string CsvConfigPath = "Configs/CSVConfigs/";
        /// <summary>
        /// Access to configuration tables with lazy initialization
        /// </summary>
        public static Tables Tables
        {
            get
            {
                if (!_isInitialized)
                {
                    Initialize();
                }
                return _tables;
            }
        }
        /// <summary>
        /// Explicit initialization method
        /// </summary>
        public static void Initialize()
        {
            if (_isInitialized) 
                return;
            try
            {
                _tables = new Tables(LoadJson);
                _isInitialized = true;
                Debug.Log("ConfigSystem initialized successfully.");
            }
            catch (Exception ex)
            {
                Debug.LogError($"ConfigSystem initialization failed: {ex.Message}");
                throw new InvalidOperationException("ConfigSystem initialization failed", ex);
            }
        }
        /// <summary>
        /// Loads JSON configuration file
        /// </summary>
        private static string LoadJson(string fileName)
        {
            return LoadConfigFile(JsonConfigPath, fileName);
        }
        /// <summary>
        /// Loads CSV configuration file
        /// </summary>
        private static string LoadCSV(string fileName)
        {
            return LoadConfigFile(CsvConfigPath, fileName);
        }
        /// <summary>
        /// Generic config file loader
        /// </summary>
        private static string LoadConfigFile(string basePath, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("File name cannot be null or empty", nameof(fileName));
            }
            string fullPath = $"{basePath}{fileName}";
            TextAsset textAsset = Resources.Load<TextAsset>(fullPath);
            if (textAsset == null)
            {
                throw new System.IO.FileNotFoundException(
                    $"Config file '{fileName}' not found at path '{fullPath}'. " +
                    "Ensure it exists in the Resources folder with the correct extension.");
            }
            return textAsset.text;
        }
    }
}
