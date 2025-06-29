using Engine;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ConfigSystem.Initialize();
        Debug.Log("ConfigSystem loaded successfully.");
        var config = ConfigSystem.Tables.TbTest3.Get(1);
        Debug.Log($"test 3 = {config}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
