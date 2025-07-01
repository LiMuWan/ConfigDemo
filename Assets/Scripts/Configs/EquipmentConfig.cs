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
    
		public TbEquipmentConfig(string json)
		{
			_dataMap = JsonHelper.ParseDictionary<EquipmentConfig>(json);
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
		public string Name { get; set; }
		public string Type { get; set; }
		public string Rarity { get; set; }
		public int Power { get; set; }
		public int LevelRequired { get; set; }

		/// <summary>
		/// Returns a string representation of the object for debugging purposes.
		/// </summary>
		/// <returns>A string containing all property values.</returns>
		public override string ToString()
		{
			var sb = new System.Text.StringBuilder();
			sb.AppendLine($"--- EquipmentConfig Object (Id: {Id}) ---");
			sb.AppendLine($"Name: {Name ?? "null"}");
			sb.AppendLine($"Type: {Type ?? "null"}");
			sb.AppendLine($"Rarity: {Rarity ?? "null"}");
			sb.AppendLine($"Power: {this.Power}");
			sb.AppendLine($"LevelRequired: {this.LevelRequired}");
			sb.AppendLine($"--------------------");
			return sb.ToString();
		}
	}
}
