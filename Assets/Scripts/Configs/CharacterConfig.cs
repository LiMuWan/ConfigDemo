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
			sb.AppendLine($"--- CharacterConfig Object ---");
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
