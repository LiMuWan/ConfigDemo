// Code generated from test: Test3, DO NOT EDIT.
using System.Linq;
using Engine.JsonHelper;

namespace Config 
{
	public class TbTest3 
	{
		private readonly System.Collections.Generic.Dictionary<int, Test3> _dataMap;
		private readonly System.Collections.Generic.List<Test3> _dataList;
    
		public TbTest3(string json)
		{
			_dataMap = JsonHelper.ParseDictionary<Test3>(json);
			_dataList = _dataMap.Values.ToList();
		}

		public System.Collections.Generic.Dictionary<int, Test3> DataMap => _dataMap;
		public System.Collections.Generic.List<Test3> DataList => _dataList;

		public Test3 GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
		public Test3 Get(int key) => _dataMap[key];
		public Test3 this[int key] => _dataMap[key];
	}

	public class Test3 : BaseEntity 
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Speed { get; set; }
		public long MaxSpeed { get; set; }
		public double Damage { get; set; }
		public float Crit { get; set; }
		public string Items { get; set; }
		public string Items1 { get; set; }
		public string Items2 { get; set; }
		public string Items3 { get; set; }
		public string Items4 { get; set; }

		/// <summary>
		/// Returns a string representation of the object for debugging purposes.
		/// </summary>
		/// <returns>A string containing all property values.</returns>
		public override string ToString()
		{
			// Use StringBuilder for efficient string construction.
			var sb = new System.Text.StringBuilder();

			sb.AppendLine($"--- Test3 Object ---");
			sb.AppendLine($"Id: {Id}");
			sb.AppendLine($"Name: {Name}");
			sb.AppendLine($"Speed: {Speed}");
			sb.AppendLine($"MaxSpeed: {MaxSpeed}");
			sb.AppendLine($"Damage: {Damage}");
			sb.AppendLine($"Crit: {Crit}");
			sb.AppendLine($"Items: {Items}");
			sb.AppendLine($"Items1: {Items1}");
			sb.AppendLine($"Items2: {Items2}");
			sb.AppendLine($"Items3: {Items3}");
			sb.AppendLine($"Items4: {Items4}");
			sb.AppendLine($"--------------------");

			return sb.ToString();
		}
	}
}
