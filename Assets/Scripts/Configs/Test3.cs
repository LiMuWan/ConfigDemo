// Code generated from test: Test3, DO NOT EDIT.
using System.Linq;
using System.Collections.Generic;
using LRR.Utilities;

namespace Config 
{
	public class TbTest3 
	{
		private readonly Dictionary<int, Test3> _dataMap;
		private readonly List<Test3> _dataList;
    
		public TbTest3(string json)
		{
			_dataMap = JsonHelper.ParseDictionary<Test3>(json);
			_dataList = _dataMap.Values.ToList();
		}

		public Dictionary<int, Test3> DataMap => _dataMap;
		public List<Test3> DataList => _dataList;

		public Test3 GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
		public Test3 Get(int key) => _dataMap[key];
		public Test3 this[int key] => _dataMap[key];
	}

	public class Test3 : BaseEntity 
	{
		public int id { get; set; }
		public string name { get; set; }
		public int speed { get; set; }
		public long max_speed { get; set; }
		public double damage { get; set; }
		public float crit { get; set; }
		public List<int> items_1 { get; set; }
		public List<long> items_2 { get; set; }
		public List<float> items_3 { get; set; }
		public List<string> items_4 { get; set; }
		public List<bool> items_5 { get; set; }

		/// <summary>
		/// Returns a string representation of the object for debugging purposes.
		/// </summary>
		/// <returns>A string containing all property values.</returns>
		public override string ToString()
		{
			var sb = new System.Text.StringBuilder();
			sb.AppendLine($"--- Test3 Object ---");
			sb.AppendLine($"id: {this.id}");
			sb.AppendLine($"name: {name ?? "null"}");
			sb.AppendLine($"speed: {this.speed}");
			sb.AppendLine($"max_speed: {this.max_speed}");
			sb.AppendLine($"damage: {this.damage}");
			sb.AppendLine($"crit: {this.crit}");
			sb.AppendLine($"items_1: {(items_1 != null ? string.Join(", ", items_1) : "null")}");
			sb.AppendLine($"items_2: {(items_2 != null ? string.Join(", ", items_2) : "null")}");
			sb.AppendLine($"items_3: {(items_3 != null ? string.Join(", ", items_3) : "null")}");
			sb.AppendLine($"items_4: {(items_4 != null ? string.Join(", ", items_4) : "null")}");
			sb.AppendLine($"items_5: {(items_5 != null ? string.Join(", ", items_5) : "null")}");
			sb.AppendLine($"--------------------");
			return sb.ToString();
		}
	}
}
