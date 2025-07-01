using System;
using System.Collections.Generic;

namespace Config
{
    [Serializable]
    public class BaseEntity
    {
        public int id;
        
        /// <summary>
        /// Helper method to join a list into a string or return "null" if the list is null.
        /// </summary>
        protected string JoinListOrNull<T>(List<T> list)
        {
            // 如果列表为 null，返回 "null"
            // 如果列表为空，返回 "[]" 或其他表示空列表的字符串
            // 否则，使用 string.Join(", ", list) 连接
            if (list == null)
            {
                return "null";
            }
            // 如果你希望空列表显示为 "[]" 而不是 "null"，可以这样修改：
            // if (list.Count == 0) return "[]";
            return string.Join(", ", list);
        }
    }
}
