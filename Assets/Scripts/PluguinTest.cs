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
    AndroidJavaClass portePlugin;
    AndroidJavaClass _pluginUnityClass;
    AndroidJavaObject _instance;


    void Start()
    {
        _pluginUnityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        portePlugin = new AndroidJavaClass(className);
        _instance = new AndroidJavaObject(className);
        //_instance = portePlugin.CallStatic<AndroidJavaObject>("GetInstance");
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
