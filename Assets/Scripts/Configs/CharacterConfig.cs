// Code generated from 配置表: CharacterConfig, DO NOT EDIT.
using System;
using System.Linq;
using System.Collections.Generic;
using LRR.Utilities; // 假设这个命名空间包含 JsonHelper 和 JoinListOrNull

namespace Config 
{
public class TbCharacterConfig 
	{
		/// <summary>
		/// The dictionary mapping keys to data entries.
		/// </summary>
		public Dictionary<int, CharacterConfig> DataMap { get; }

		/// <summary>
		/// A list containing all data entries.
		/// </summary>
		public List<CharacterConfig> DataList { get; }
    
		public TbCharacterConfig(string json)
		{
			DataMap = JsonHelper.ParseDictionary<CharacterConfig>(json) ?? new Dictionary<int, CharacterConfig>();
			DataList = DataMap.Values.ToList();
		}

		/// <summary>
		/// Gets a data entry by key, returning null if not found.
		/// </summary>
		/// <param name="key">The key of the data entry.</param>
		/// <returns>The data entry, or null if not found.</returns>
		public CharacterConfig GetOrDefault(int key) => DataMap.TryGetValue(key, out var v) ? v : null;

		/// <summary>
		/// Gets a data entry by key. Throws KeyNotFoundException if the key does not exist.
		/// </summary>
		/// <param name="key">The key of the data entry.</param>
		/// <returns>The data entry.</returns>
		public CharacterConfig Get(int key) => DataMap[key];

		/// <summary>
		/// Provides indexer access to data entries by key.
		/// </summary>
		/// <param name="key">The key of the data entry.</param>
		/// <returns>The data entry.</returns>
		public CharacterConfig this[int key] => DataMap[key];
	}

	public class CharacterConfig : BaseEntity 
	{
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
			sb.AppendLine($"--- CharacterConfig Object (id: {id}) ---");
			sb.AppendLine($"name: {name ?? "null"}");
			sb.AppendLine($"speed: {this.speed}");
			sb.AppendLine($"max_speed: {this.max_speed}");
			sb.AppendLine($"damage: {this.damage}");
			sb.AppendLine($"crit: {this.crit.ToString("F2")}");
			sb.AppendLine($"--------------------");
			return sb.ToString();
		}
	}
}
