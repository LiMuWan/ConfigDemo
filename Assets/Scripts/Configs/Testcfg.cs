// Code generated from test: Testcfg, DO NOT EDIT.
using System.Linq;
using Engine.JsonHelper;

namespace Config 
{
	public class TbTestcfg 
	{
		private readonly System.Collections.Generic.Dictionary<string, Testcfg> _dataMap;
		private readonly System.Collections.Generic.List<Testcfg> _dataList;
    
		public TbTestcfg(string json)
		{
			_dataMap = JsonHelper.ParseStringDictionary<Testcfg>(json);
			_dataList = _dataMap.Values.ToList();
		}

		public System.Collections.Generic.Dictionary<string, Testcfg> DataMap => _dataMap;
		public System.Collections.Generic.List<Testcfg> DataList => _dataList;

		public Testcfg GetOrDefault(string key) => _dataMap.TryGetValue(key, out var v) ? v : null;
		public Testcfg Get(string key) => _dataMap[key];
		public Testcfg this[string key] => _dataMap[key];
	}

	public class Testcfg : BaseEntity 
	{
		public string CharacterConfig { get; set;}
		public string Name { get; set;}
		public string Speed { get; set;}
		public string MaxSpeed { get; set;}
		public string Damag { get; set;}
		public string Crit { get; set;}
		public string Items { get; set;}
	}
}
