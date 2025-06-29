using System;
using System.Collections.Generic;
using Config;
using UnityEngine; // 保持对 Resources.Load 的引用

namespace Engine // 假设命名空间是 TEngine
{
    /// <summary>
    /// 配置加载静态工具。
    /// </summary>
    public static class ConfigSystem
    {
        // _init 标志仍然有用，用于防止多次加载（尽管显式初始化后可能不再严格需要，但保持其逻辑是安全的）
        private static bool _init = false; 

        private static Tables _tables; // 静态成员

        /// <summary>
        /// 获取配置表。如果未初始化，则会自动加载。
        /// 注意：此属性的 get 访问器仍然提供了延迟加载的机制，
        /// 但为了更主动地控制初始化，请使用 Initialize() 方法。
        /// </summary>
        public static Tables Tables
        {
            get
            {
                // 如果未初始化，则调用 Load()。
                // 如果您总是先调用 Initialize()，这一步可以减少一层检查，但保留它也没问题。
                if (!_init)
                {
                    Load();
                }
                return _tables;
            }
        }

        /// <summary>
        /// 手动初始化配置加载器。
        /// 调用此方法可以确保配置在需要之前被加载。
        /// </summary>
        public static void Initialize()
        {
            if (!_init)
            {
                Load();
            }
            else
            {
                Debug.Log("ConfigSystem has already been initialized.");
            }
        }

        /// <summary>
        /// 加载配置。这是一个私有静态方法，供静态 Load() 方法（或 Initialize()）调用。
        /// </summary>
        private static void Load()
        {
            try
            {
                // 注意：LoadJson 需要在有可用 Unity 环境时调用
                _tables = new Tables(LoadJson); 
                _init = true;
                Debug.Log("ConfigSystem loaded successfully.");
            }
            catch (Exception ex)
            {
                // 在加载过程中捕获异常，并进行更详细的错误报告
                Debug.LogError($"ConfigSystem: Failed to load configurations. Error: {ex.Message}\nStack Trace: {ex.StackTrace}");
                // 可以在这里选择是否抛出异常，或者让 _init 保持 false，后续访问 Tables 时会再次尝试加载
                // 为了防止无限循环加载，可以在这里设置 _init = true，但让 _tables 为 null，并在 Tables 属性中进行空检查
                // 或者更简单地，如果加载失败，就让 _init 保持 false，后续访问时依然会报错。
                // 这里我们选择在抛出异常前记录错误。
                throw; // 重新抛出异常，以便调用者知道加载失败
            }
        }

        /// <summary>
        /// 加载json。这是一个静态私有方法，供静态Load方法调用。
        /// </summary>
        /// <param name="file">FileName</param>
        /// <returns>JSON字符串。</returns>
        private static string LoadJson(string file)
        {
            // 确保在 Unity 的 Resources 文件夹中存在该文件。
            // 在静态类中直接调用 Resources.Load 需要确保 Unity 的 Application
            // 已经完全初始化并且 Resources 文件夹是可访问的。
            // 通常这会在 Awake() 或 Start() 方法中被确保。
            // 如果此静态类在编辑器脚本或其他需要独立运行的环境中被使用，
            // 可能需要一个配置来指定 JSON 加载的路径。

            TextAsset textAsset = Resources.Load<TextAsset>(file);
            
            if (textAsset == null)
            {
                // 更好的错误处理：明确告知问题所在
                Debug.LogError($"ConfigSystem: Failed to load TextAsset '{file}'. Ensure the file exists in a folder named 'Resources' in your Assets.");
                // 抛出异常可能更适合这种关键资源的加载失败场景
                throw new Exception($"ConfigSystem: TextAsset '{file}' not found."); 
            }
            
            // 返回加载的文本内容
            return textAsset.text;
        }
    }
}
