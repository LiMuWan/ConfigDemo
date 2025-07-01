using LRR.Utilities;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ConfigSystem.Initialize();
        var characterSkillsConfig = ConfigSystem.Tables.TbCharacterSkillsConfig.Get(1);
        var characterConfig = ConfigSystem.Tables.TbCharacterConfig.Get(4);
        Debug.Log($"TbCharacterSkillsConfig data  = {characterSkillsConfig}");
        Debug.Log($"TbCharacterConfig data  = {characterConfig}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
