using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Engine.JsonHelper
{
    /// <summary>
    /// 默认 JSON 函数集静态辅助器。
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// 将对象序列化为 JSON 字符串。
        /// </summary>
        /// <param name="obj">要序列化的对象。</param>
        /// <returns>序列化后的 JSON 字符串。</returns>
        public static string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 将 JSON 字符串反序列化为对象。
        /// </summary>
        /// <typeparam name="T">对象类型。</typeparam>
        /// <param name="json">要反序列化的 JSON 字符串。</param>
        /// <returns>反序列化后的对象。</returns>
        public static T ToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 将 JSON 字符串反序列化为对象。
        /// </summary>
        /// <param name="objectType">对象类型。</param>
        /// <param name="json">要反序列化的 JSON 字符串。</param>
        /// <returns>反序列化后的对象。</returns>
        public static object ToObject(Type objectType, string json)
        {
            // 假设 objectType 是您想要反序列化的具体类型，例如 typeof(MyClass)
            return JsonConvert.DeserializeObject(json, objectType);
        }
        
        /// <summary>
        /// 将 JSON 字符串反序列化为 Dictionary<int, T>。
        /// </summary>
        /// <typeparam name="T">字典值的类型。</typeparam>
        /// <param name="json">要反序列化的 JSON 字符串。</param>
        /// <returns>反序列化后的 Dictionary。</returns>
        public static Dictionary<int, T> ParseDictionary<T>(string json) where T : class
        {
            var jsonObject = JObject.Parse(json);
            var dict = new Dictionary<int, T>();

            foreach (var kvp in jsonObject)
            {
                T item = JsonConvert.DeserializeObject<T>(kvp.Value.ToString());
                // 假设键总是可以解析为 int
                dict.Add(int.Parse(kvp.Key), item);
            }

            return dict;
        }

        /// <summary>
        /// 将 JSON 字符串反序列化为 Dictionary<string, T>。
        /// </summary>
        /// <typeparam name="T">字典值的类型。</typeparam>
        /// <param name="json">要反序列化的 JSON 字符串。</param>
        /// <returns>反序列化后的 Dictionary。</returns>
        public static Dictionary<string, T> ParseStringDictionary<T>(string json) where T : class
        {
            var jsonObject = JObject.Parse(json);
            var dict = new Dictionary<string, T>();

            foreach (var kvp in jsonObject)
            {
                T item = JsonConvert.DeserializeObject<T>(kvp.Value.ToString());
                dict.Add(kvp.Key, item);
            }

            return dict;
        }
    }
}
