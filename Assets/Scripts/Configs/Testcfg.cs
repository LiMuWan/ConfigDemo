// Code generated from test: Testcfg, DO NOT EDIT.
using System.Linq;
using System.Collections.Generic;
using Engine;

namespace Config 
{
	public class TbTestcfg 
	{
		private readonly Dictionary<int, Testcfg> _dataMap;
		private readonly List<Testcfg> _dataList;
    
		public TbTestcfg(string csvContent)
		{
			_dataMap = CsvHelper.ParseDictionary<int, Testcfg>(csvContent);
			_dataList = _dataMap.Values.ToList();
		}

		public Dictionary<int, Testcfg> DataMap => _dataMap;
		public List<Testcfg> DataList => _dataList;

		public Testcfg GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
		public Testcfg Get(int key) => _dataMap[key];
		public Testcfg this[int key] => _dataMap[key];
	}

	public class Testcfg : BaseEntity 
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
			sb.AppendLine($"--- Testcfg Object ---");
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
