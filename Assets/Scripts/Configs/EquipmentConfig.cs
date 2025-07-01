// Code generated from 配置表: EquipmentConfig, DO NOT EDIT.
using System;
using System.Linq;
using System.Collections.Generic;
using LRR.Utilities;

namespace Config 
{
public class TbEquipmentConfig 
	{
		private readonly Dictionary<int, EquipmentConfig> _dataMap;
		private readonly List<EquipmentConfig> _dataList;
    
		public TbEquipmentConfig(string json)
		{
			try
			{
			_dataMap = JsonHelper.ParseDictionary<EquipmentConfig>(json);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed to parse data for TbEquipmentConfig.", ex);
			}
            
			if (_dataMap == null)
			{
				_dataMap = new Dictionary<int, EquipmentConfig>();
				// Optional: throw an exception if data is expected
				// throw new Exception("Parsed data resulted in a null dictionary for TbEquipmentConfig.");
			}

			_dataList = _dataMap.Values.ToList();
		}

		public Dictionary<int, EquipmentConfig> DataMap => _dataMap;
		public List<EquipmentConfig> DataList => _dataList;

		/// <summary>
		/// Gets a data entry by key, returning null if not found.
		/// </summary>
		public EquipmentConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;

		/// <summary>
		/// Gets a data entry by key. Throws KeyNotFoundException if the key does not exist.
		/// </summary>
		public EquipmentConfig Get(int key) => _dataMap[key];

		/// <summary>
		/// Provides indexer access to data entries by key.
		/// </summary>
		public EquipmentConfig this[int key] => _dataMap[key];
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
