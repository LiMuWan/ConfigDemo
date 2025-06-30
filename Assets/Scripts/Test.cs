using LRR.Utilities;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ConfigSystem.Initialize();
        var config = ConfigSystem.Tables.TbCharacterSkillsConfig.Get(1);
        Debug.Log($"TbCharacterSkillsConfig data  = {config}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
