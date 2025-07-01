// Code generated from 配置表: CharacterConfig, DO NOT EDIT.
using System.Linq;
using System.Collections.Generic;
using LRR.Utilities;

namespace Config 
{
	public class TbCharacterConfig 
	{
		private readonly Dictionary<int, CharacterConfig> _dataMap;
		private readonly List<CharacterConfig> _dataList;
    
		public TbCharacterConfig(string json)
		{
			_dataMap = JsonHelper.ParseDictionary<CharacterConfig>(json);
			_dataList = _dataMap.Values.ToList();
		}

		public Dictionary<int, CharacterConfig> DataMap => _dataMap;
		public List<CharacterConfig> DataList => _dataList;

		public CharacterConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
		public CharacterConfig Get(int key) => _dataMap[key];
		public CharacterConfig this[int key] => _dataMap[key];
	}

	public class CharacterConfig : BaseEntity 
	{
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
			var sb = new System.Text.StringBuilder();
			sb.AppendLine($"--- CharacterConfig Object (Id: {Id}) ---");
			sb.AppendLine($"Name: {Name ?? "null"}");
			sb.AppendLine($"Speed: {this.Speed}");
			sb.AppendLine($"MaxSpeed: {this.MaxSpeed}");
			sb.AppendLine($"Damage: {this.Damage}");
			sb.AppendLine($"Crit: {this.Crit}");
			sb.AppendLine($"--------------------");
			return sb.ToString();
		}
	}
}
