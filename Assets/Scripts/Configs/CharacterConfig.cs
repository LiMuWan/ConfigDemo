// Code generated from 配置表: CharacterConfig, DO NOT EDIT.
using System;
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
			try
			{
			_dataMap = JsonHelper.ParseDictionary<CharacterConfig>(json);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed to parse data for TbCharacterConfig.", ex);
			}
            
			if (_dataMap == null)
			{
				_dataMap = new Dictionary<int, CharacterConfig>();
				// Optional: throw an exception if data is expected
				// throw new Exception("Parsed data resulted in a null dictionary for TbCharacterConfig.");
			}

			_dataList = _dataMap.Values.ToList();
		}

		public Dictionary<int, CharacterConfig> DataMap => _dataMap;
		public List<CharacterConfig> DataList => _dataList;

		/// <summary>
		/// Gets a data entry by key, returning null if not found.
		/// </summary>
		public CharacterConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;

		/// <summary>
		/// Gets a data entry by key. Throws KeyNotFoundException if the key does not exist.
		/// </summary>
		public CharacterConfig Get(int key) => _dataMap[key];

		/// <summary>
		/// Provides indexer access to data entries by key.
		/// </summary>
		public CharacterConfig this[int key] => _dataMap[key];
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
