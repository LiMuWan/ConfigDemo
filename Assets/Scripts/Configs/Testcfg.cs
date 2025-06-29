// Code generated from test: Testcfg, DO NOT EDIT.
using System.Linq;
using System.Collections.Generic;
using Engine.JsonHelper;

namespace Config 
{
	public class TbTestcfg 
	{
		private readonly System.Collections.Generic.Dictionary<int, Testcfg> _dataMap;
		private readonly System.Collections.Generic.List<Testcfg> _dataList;
    
		public TbTestcfg(string json)
		{
			_dataMap = JsonHelper.ParseDictionary<Testcfg>(json);
			_dataList = _dataMap.Values.ToList();
		}

		public System.Collections.Generic.Dictionary<int, Testcfg> DataMap => _dataMap;
		public System.Collections.Generic.List<Testcfg> DataList => _dataList;

		public Testcfg GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
		public Testcfg Get(int key) => _dataMap[key];
		public Testcfg this[int key] => _dataMap[key];
	}

	public class Testcfg : BaseEntity 
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Speed { get; set; }
		public int MaxSpeed { get; set; }
		public int Damage { get; set; }
		public float Crit { get; set; }

		/// <summary>
		/// Returns a string representation of the object for debugging purposes.
		/// </summary>
		/// <returns>A string containing all property values.</returns>
		public override string ToString()
		{
			// Use StringBuilder for efficient string construction.
			var sb = new System.Text.StringBuilder();

			sb.AppendLine($"--- Testcfg Object ---");
			sb.AppendLine($"Id: {Id}");
			sb.AppendLine($"Name: {Name ?? "null"}");
			sb.AppendLine($"Speed: {Speed}");
			sb.AppendLine($"MaxSpeed: {MaxSpeed}");
			sb.AppendLine($"Damage: {Damage}");
			sb.AppendLine($"Crit: {Crit}");
			sb.AppendLine($"--------------------");

			return sb.ToString();
		}
	}
}
