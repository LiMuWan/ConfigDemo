// Code generated from 配置表: CharacterSkillsConfig, DO NOT EDIT.
using System;
using System.Linq;
using System.Collections.Generic;
using LRR.Utilities; // 假设这个命名空间包含 JsonHelper 和 JoinListOrNull

namespace Config 
{
public class TbCharacterSkillsConfig 
	{
		/// <summary>
		/// The dictionary mapping keys to data entries.
		/// </summary>
		public Dictionary<int, CharacterSkillsConfig> DataMap { get; }

		/// <summary>
		/// A list containing all data entries.
		/// </summary>
		public List<CharacterSkillsConfig> DataList { get; }
    
		public TbCharacterSkillsConfig(string json)
		{
			DataMap = JsonHelper.ParseDictionary<CharacterSkillsConfig>(json) ?? new Dictionary<int, CharacterSkillsConfig>();
			DataList = DataMap.Values.ToList();
		}

		/// <summary>
		/// Gets a data entry by key, returning null if not found.
		/// </summary>
		/// <param name="key">The key of the data entry.</param>
		/// <returns>The data entry, or null if not found.</returns>
		public CharacterSkillsConfig GetOrDefault(int key) => DataMap.TryGetValue(key, out var v) ? v : null;

		/// <summary>
		/// Gets a data entry by key. Throws KeyNotFoundException if the key does not exist.
		/// </summary>
		/// <param name="key">The key of the data entry.</param>
		/// <returns>The data entry.</returns>
		public CharacterSkillsConfig Get(int key) => DataMap[key];

		/// <summary>
		/// Provides indexer access to data entries by key.
		/// </summary>
		/// <param name="key">The key of the data entry.</param>
		/// <returns>The data entry.</returns>
		public CharacterSkillsConfig this[int key] => DataMap[key];
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
			sb.AppendLine($"skills: {JoinListOrNull(skills)}");
			sb.AppendLine($"max_speed: {this.max_speed}");
			sb.AppendLine($"damage: {this.damage}");
			sb.AppendLine($"crit: {this.crit.ToString("F2")}");
			sb.AppendLine($"skill_cooldowns: {JoinListOrNull(skill_cooldowns)}");
			sb.AppendLine($"skill_costs: {JoinListOrNull(skill_costs)}");
			sb.AppendLine($"skill_types: {JoinListOrNull(skill_types)}");
			sb.AppendLine($"is_available: {this.is_available}");
			sb.AppendLine($"--------------------");
			return sb.ToString();
		}
	}
}
