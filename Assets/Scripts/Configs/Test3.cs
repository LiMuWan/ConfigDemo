// Code generated from test: Test3, DO NOT EDIT.
using System.Linq;

namespace Config 
{
	public class TbTest3 
	{
		private readonly System.Collections.Generic.Dictionary<int, Test3> _dataMap;
		private readonly System.Collections.Generic.List<Test3> _dataList;
    
		public TbTest3(string json)
		{
			_dataMap = Utility.Json.ParseDictionary<Test3>(json);
			_dataList = _dataMap.Values.ToList();
		}

		public System.Collections.Generic.Dictionary<int, Test3> DataMap => _dataMap;
		public System.Collections.Generic.List<Test3> DataList => _dataList;

		public Test3 GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
		public Test3 Get(int key) => _dataMap[key];
		public Test3 this[int key] => _dataMap[key];
	}

	public class Test3 : BaseEntity 
	{
		public int Id { get; set;}
		public string Name { get; set;}
		public int Speed { get; set;}
		public long MaxSpeed { get; set;}
		public double Damage { get; set;}
		public float Crit { get; set;}
		public string Items { get; set;}
		public string Items1 { get; set;}
		public string Items2 { get; set;}
		public string Items3 { get; set;}
		public string Items3 { get; set;}
	}
}
