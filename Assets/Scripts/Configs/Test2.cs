// Code generated from test: Test2, DO NOT EDIT.
using System.Linq;
using Engine.JsonHelper;

namespace Config 
{
	public class TbTest2 
	{
		private readonly System.Collections.Generic.Dictionary<string, Test2> _dataMap;
		private readonly System.Collections.Generic.List<Test2> _dataList;
    
		public TbTest2(string json)
		{
			_dataMap = JsonHelper.ParseStringDictionary<Test2>(json);
			_dataList = _dataMap.Values.ToList();
		}

		public System.Collections.Generic.Dictionary<string, Test2> DataMap => _dataMap;
		public System.Collections.Generic.List<Test2> DataList => _dataList;

		public Test2 GetOrDefault(string key) => _dataMap.TryGetValue(key, out var v) ? v : null;
		public Test2 Get(string key) => _dataMap[key];
		public Test2 this[string key] => _dataMap[key];
	}

	public class Test2 : BaseEntity 
	{
		public string CharacterConfig { get; set; }
		public string Name { get; set; }
		public string Speed { get; set; }
		public string MaxSpeed { get; set; }
		public string Damag { get; set; }
		public string Crit { get; set; }
		public string Items { get; set; }

		/// <summary>
		/// Returns a string representation of the object for debugging purposes.
		/// </summary>
		/// <returns>A string containing all property values.</returns>
		public override string ToString()
		{
			// Use StringBuilder for efficient string construction.
			var sb = new System.Text.StringBuilder();

			sb.AppendLine($"--- Test2 Object ---");
			sb.AppendLine($"CharacterConfig: {CharacterConfig ?? "null"}");
			sb.AppendLine($"Name: {Name ?? "null"}");
			sb.AppendLine($"Speed: {Speed ?? "null"}");
			sb.AppendLine($"MaxSpeed: {MaxSpeed ?? "null"}");
			sb.AppendLine($"Damag: {Damag ?? "null"}");
			sb.AppendLine($"Crit: {Crit ?? "null"}");
			sb.AppendLine($"Items: {Items ?? "null"}");
			sb.AppendLine($"--------------------");

			return sb.ToString();
		}
	}
}
