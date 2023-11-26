using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PluguinTest : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private const string packageName = "com.logger.pluginporte";
    private const string className = packageName + ".PortePlugin";


#if UNITY_ANDROID
    AndroidJavaClass portePluginClass;
    AndroidJavaObject _instance;


    void Start()
    {
        portePluginClass = new AndroidJavaClass(className);
        _instance = portePluginClass.CallStatic<AndroidJavaObject>("GetInstance");
    }

    void Update()
    {
        
    }

    public void Alert()
    {
        Debug.Log("Play Alert");
        text.text = _instance.Call<string>("GetLOGTAG");
    }
#endif
}
