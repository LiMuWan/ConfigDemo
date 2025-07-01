// Code generated from 配置表: EquipmentConfig, DO NOT EDIT.
using System;
using System.Linq;
using System.Collections.Generic;
using LRR.Utilities; // 假设这个命名空间包含 JsonHelper 和 JoinListOrNull

namespace Config 
{
public class TbEquipmentConfig 
	{
		/// <summary>
		/// The dictionary mapping keys to data entries.
		/// </summary>
		public Dictionary<int, EquipmentConfig> DataMap { get; }

		/// <summary>
		/// A list containing all data entries.
		/// </summary>
		public List<EquipmentConfig> DataList { get; }
    
		public TbEquipmentConfig(string json)
		{
			DataMap = JsonHelper.ParseDictionary<EquipmentConfig>(json) ?? new Dictionary<int, EquipmentConfig>();
			DataList = DataMap.Values.ToList();
		}

		/// <summary>
		/// Gets a data entry by key, returning null if not found.
		/// </summary>
		/// <param name="key">The key of the data entry.</param>
		/// <returns>The data entry, or null if not found.</returns>
		public EquipmentConfig GetOrDefault(int key) => DataMap.TryGetValue(key, out var v) ? v : null;

		/// <summary>
		/// Gets a data entry by key. Throws KeyNotFoundException if the key does not exist.
		/// </summary>
		/// <param name="key">The key of the data entry.</param>
		/// <returns>The data entry.</returns>
		public EquipmentConfig Get(int key) => DataMap[key];

		/// <summary>
		/// Provides indexer access to data entries by key.
		/// </summary>
		/// <param name="key">The key of the data entry.</param>
		/// <returns>The data entry.</returns>
		public EquipmentConfig this[int key] => DataMap[key];
	}

	public class EquipmentConfig : BaseEntity 
	{
		public string name { get; set; }
		public string type { get; set; }
		public string rarity { get; set; }
		public int power { get; set; }
		public int level_required { get; set; }

		/// <summary>
		/// Returns a string representation of the object for debugging purposes.
		/// </summary>
		/// <returns>A string containing all property values.</returns>
		public override string ToString()
		{
			var sb = new System.Text.StringBuilder();
			sb.AppendLine($"--- EquipmentConfig Object (id: {id}) ---");
			sb.AppendLine($"name: {name ?? "null"}");
			sb.AppendLine($"type: {type ?? "null"}");
			sb.AppendLine($"rarity: {rarity ?? "null"}");
			sb.AppendLine($"power: {this.power}");
			sb.AppendLine($"level_required: {this.level_required}");
			sb.AppendLine($"--------------------");
			return sb.ToString();
		}
	}
}
