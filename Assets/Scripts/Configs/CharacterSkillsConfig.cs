// Code generated from 配置表: CharacterSkillsConfig, DO NOT EDIT.
using System.Linq;
using System.Collections.Generic;
using LRR.Utilities;

namespace Config 
{
	public class TbCharacterSkillsConfig 
	{
		private readonly Dictionary<int, CharacterSkillsConfig> _dataMap;
		private readonly List<CharacterSkillsConfig> _dataList;
    
		public TbCharacterSkillsConfig(string json)
		{
			_dataMap = JsonHelper.ParseDictionary<CharacterSkillsConfig>(json);
			_dataList = _dataMap.Values.ToList();
		}

		public Dictionary<int, CharacterSkillsConfig> DataMap => _dataMap;
		public List<CharacterSkillsConfig> DataList => _dataList;

		public CharacterSkillsConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
		public CharacterSkillsConfig Get(int key) => _dataMap[key];
		public CharacterSkillsConfig this[int key] => _dataMap[key];
	}

	public class CharacterSkillsConfig : BaseEntity 
	{
		public string Name { get; set; }
		public List<string> Skills { get; set; }
		public int MaxSpeed { get; set; }
		public int Damage { get; set; }
		public float Crit { get; set; }
		public List<int> SkillCooldowns { get; set; }
		public List<int> SkillCosts { get; set; }
		public List<string> SkillTypes { get; set; }
		public bool IsAvailable { get; set; }

		/// <summary>
		/// Returns a string representation of the object for debugging purposes.
		/// </summary>
		/// <returns>A string containing all property values.</returns>
		public override string ToString()
		{
			var sb = new System.Text.StringBuilder();
			sb.AppendLine($"--- CharacterSkillsConfig Object (Id: {Id}) ---");
			sb.AppendLine($"Name: {Name ?? "null"}");
			sb.AppendLine($"Skills: " + (Skills != null ? string.Join(\", \", Skills) : "null"));
			sb.AppendLine($"MaxSpeed: {this.MaxSpeed}");
			sb.AppendLine($"Damage: {this.Damage}");
			sb.AppendLine($"Crit: {this.Crit}");
			sb.AppendLine($"SkillCooldowns: " + (SkillCooldowns != null ? string.Join(\", \", SkillCooldowns) : "null"));
			sb.AppendLine($"SkillCosts: " + (SkillCosts != null ? string.Join(\", \", SkillCosts) : "null"));
			sb.AppendLine($"SkillTypes: " + (SkillTypes != null ? string.Join(\", \", SkillTypes) : "null"));
			sb.AppendLine($"IsAvailable: {this.IsAvailable}");
			sb.AppendLine($"--------------------");
			return sb.ToString();
		}
	}
}
