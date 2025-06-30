// Code generated from 配置表: EquipmentConfig, DO NOT EDIT.
using System.Linq;
using System.Collections.Generic;
using LRR.Utilities;

namespace Config 
{
	public class TbEquipmentConfig 
	{
		private readonly Dictionary<int, EquipmentConfig> _dataMap;
		private readonly List<EquipmentConfig> _dataList;
    
		public TbEquipmentConfig(string csvContent)
		{
			_dataMap = CsvHelper.ParseDictionary<int, EquipmentConfig>(csvContent);
			_dataList = _dataMap.Values.ToList();
		}

		public Dictionary<int, EquipmentConfig> DataMap => _dataMap;
		public List<EquipmentConfig> DataList => _dataList;

		public EquipmentConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
		public EquipmentConfig Get(int key) => _dataMap[key];
		public EquipmentConfig this[int key] => _dataMap[key];
	}

	public class EquipmentConfig : BaseEntity 
	{
		public int id { get; set; }
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
			sb.AppendLine($"--- EquipmentConfig Object ---");
			sb.AppendLine($"id: {this.id}");
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
