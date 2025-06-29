// Code generated from test: Test2, DO NOT EDIT.
using System.Linq;
using System.Collections.Generic;
using Engine.JsonHelper;

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

			sb.AppendLine($"--- Test2 Object ---");
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
