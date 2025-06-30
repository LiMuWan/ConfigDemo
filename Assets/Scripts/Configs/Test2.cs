// Code generated from test: Test2, DO NOT EDIT.
using System.Linq;
using System.Collections.Generic;
using LRR.Utilities;

namespace Config 
{
	public class TbTest2 
	{
		private readonly Dictionary<int, Test2> _dataMap;
		private readonly List<Test2> _dataList;
    
		public TbTest2(string json)
		{
			_dataMap = JsonHelper.ParseDictionary<Test2>(json);
			_dataList = _dataMap.Values.ToList();
		}

		public Dictionary<int, Test2> DataMap => _dataMap;
		public List<Test2> DataList => _dataList;

		public Test2 GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
		public Test2 Get(int key) => _dataMap[key];
		public Test2 this[int key] => _dataMap[key];
	}

	public class Test2 : BaseEntity 
	{
		public int id { get; set; }
		public string name { get; set; }
		public int speed { get; set; }
		public int max_speed { get; set; }
		public int damage { get; set; }
		public float crit { get; set; }

		/// <summary>
		/// Returns a string representation of the object for debugging purposes.
		/// </summary>
		/// <returns>A string containing all property values.</returns>
		public override string ToString()
		{
			var sb = new System.Text.StringBuilder();
			sb.AppendLine($"--- Test2 Object ---");
			sb.AppendLine($"id: {this.id}");
			sb.AppendLine($"name: {name ?? "null"}");
			sb.AppendLine($"speed: {this.speed}");
			sb.AppendLine($"max_speed: {this.max_speed}");
			sb.AppendLine($"damage: {this.damage}");
			sb.AppendLine($"crit: {this.crit}");
			sb.AppendLine($"--------------------");
			return sb.ToString();
		}
	}
}
