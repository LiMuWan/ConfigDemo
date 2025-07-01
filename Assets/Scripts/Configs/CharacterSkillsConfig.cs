// Code generated from 配置表: CharacterSkillsConfig, DO NOT EDIT.
using System;
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
			try
			{
			_dataMap = JsonHelper.ParseDictionary<CharacterSkillsConfig>(json);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed to parse data for TbCharacterSkillsConfig.", ex);
			}
            
			if (_dataMap == null)
			{
				_dataMap = new Dictionary<int, CharacterSkillsConfig>();
				// Optional: throw an exception if data is expected
				// throw new Exception("Parsed data resulted in a null dictionary for TbCharacterSkillsConfig.");
			}

			_dataList = _dataMap.Values.ToList();
		}

		public Dictionary<int, CharacterSkillsConfig> DataMap => _dataMap;
		public List<CharacterSkillsConfig> DataList => _dataList;

		/// <summary>
		/// Gets a data entry by key, returning null if not found.
		/// </summary>
		public CharacterSkillsConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;

		/// <summary>
		/// Gets a data entry by key. Throws KeyNotFoundException if the key does not exist.
		/// </summary>
		public CharacterSkillsConfig Get(int key) => _dataMap[key];

		/// <summary>
		/// Provides indexer access to data entries by key.
		/// </summary>
		public CharacterSkillsConfig this[int key] => _dataMap[key];
	}

	public class CharacterSkillsConfig : BaseEntity 
	{
		public string name { get; set; }
		public List<string> skills { get; set; }
		public int max_speed { get; set; }
		public int damage { get; set; }
		public float crit { get; set; }
		public List<int> skill_cooldowns { get; set; }
		public List<int> skill_costs { get; set; }
		public List<string> skill_types { get; set; }
		public bool is_available { get; set; }

		/// <summary>
		/// Returns a string representation of the object for debugging purposes.
		/// </summary>
		/// <returns>A string containing all property values.</returns>
		public override string ToString()
		{
			var sb = new System.Text.StringBuilder();
			sb.AppendLine($"--- CharacterSkillsConfig Object (id: {id}) ---");
			sb.AppendLine($"name: {name ?? "null"}");
			sb.AppendLine($"skills: " + (skills != null ? string.Join(\", \", skills) : "null"));
			sb.AppendLine($"max_speed: {this.max_speed}");
			sb.AppendLine($"damage: {this.damage}");
			sb.AppendLine($"crit: {this.crit.ToString("F2")}");
			sb.AppendLine($"skill_cooldowns: " + (skill_cooldowns != null ? string.Join(\", \", skill_cooldowns) : "null"));
			sb.AppendLine($"skill_costs: " + (skill_costs != null ? string.Join(\", \", skill_costs) : "null"));
			sb.AppendLine($"skill_types: " + (skill_types != null ? string.Join(\", \", skill_types) : "null"));
			sb.AppendLine($"is_available: {this.is_available}");
			sb.AppendLine($"--------------------");
			return sb.ToString();
		}
	}
}
