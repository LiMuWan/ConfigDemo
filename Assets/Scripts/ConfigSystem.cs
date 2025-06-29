using System;
using Config; // 保留，以防万一
using UnityEngine; // 保持对 Resources.Load 的引用

namespace Engine 
{
    /// <summary>
    /// 配置加载静态工具。代码精简、健壮，并优化了字符串拼接。
    /// </summary>
    public static class ConfigSystem
    {
        // _init 标志用于避免重复初始化
        private static bool _initialized = false; 

        private static Tables _tables; // 静态成员

        /// <summary>
        /// 获取配置表。如果未初始化，则自动加载。
        /// </summary>
        public static Tables Tables
        {
            get
            {
                // 确保在访问 Tables 时，配置已经加载
                EnsureInitialized();
                return _tables;
            }
        }

        /// <summary>
        /// 手动初始化配置加载器，并在首次访问时调用。
        /// </summary>
        private static void EnsureInitialized()
        {
            if (!_initialized)
            {
                LoadConfigurations();
            }
        }

        /// <summary>
        /// 公开的初始化方法，供外部代码（如 GameManager）调用。
        /// </summary>
        public static void Initialize()
        {
            EnsureInitialized(); // 调用内部的初始化逻辑
        }

        /// <summary>
        /// 加载配置。这个方法负责执行实际的加载流程。
        /// </summary>
        private static void LoadConfigurations()
        {
            try
            {
                // 注意：LoadJson 需要在有可用 Unity 环境时调用
                _tables = new Tables(LoadJson); 
                _initialized = true; // 标记为已初始化
                Debug.Log("ConfigSystem loaded successfully.");
            }
            catch (Exception ex)
            {
                // 捕获加载过程中可能发生的异常，并提供详细的错误信息
                Debug.LogError($"ConfigSystem: Failed to load configurations. Error: {ex.Message}\nStack Trace: {ex.StackTrace}");
                // 抛出异常，让调用者知道加载失败
                throw; 
            }
        }

        /// <summary>
        /// 加载JSON文件。这是核心的资源加载部分。
        /// </summary>
        /// <param name="fileName">JSON文件的名称（不包含路径和扩展名，假设在Resources/Configs/JsonConfigs/目录下）。</param>
        /// <returns>加载到的JSON字符串。</returns>
        private static string LoadJson(string fileName)
        {
            // 定义 JSON 文件所在的基础路径
            const string basePath = "Configs/JsonConfigs/";
            
            // 组合完整的资源路径
            string fullPath = basePath + fileName;

            // 使用 UnityEngine.Resources.Load 加载 TextAsset
            TextAsset textAsset = Resources.Load<TextAsset>(fullPath);
            
            if (textAsset == null)
            {
                // 提供清晰的错误信息，帮助开发者定位问题
                // 建议：确保文件确实存在于 Assets/Resources/Configs/JsonConfigs/ 路径下
                throw new System.IO.FileNotFoundException($"ConfigSystem: Failed to load TextAsset '{fileName}'. Please ensure the file exists at '{fullPath}' within your Assets/Resources folder."); 
            }
            
            // 返回加载的文本内容
            return textAsset.text;
        }
    }
}
