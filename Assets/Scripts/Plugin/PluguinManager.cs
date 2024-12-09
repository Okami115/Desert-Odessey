using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PluguinManager : MonoBehaviour
{
    private const string packName = "com.porte.porteplugin";
    private const string className = packName + ".PluginClass";

    private int currentLogType;
    private string[] tempArray;
    [SerializeField] private GameObject textPanel;
    [SerializeField] private GameObject textObject;
    [SerializeField] private List<GameObject> createdLogs;

#if UNITY_ANDROID
    
    private AndroidJavaClass pluginClass;
    private AndroidJavaClass unityClass;

    private AndroidJavaObject unityActivity;
    private AndroidJavaObject pluginInstance;

    private void Start()
    {
        currentLogType = 0;
        if (Application.platform == RuntimePlatform.Android)
        {
            pluginClass = new AndroidJavaClass(className);

            unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

            unityActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
            pluginInstance = pluginClass.CallStatic<AndroidJavaObject>("getInstance");

            if (pluginInstance == null)
            {
                Debug.Log("Not Plugin Object");
                return;
            }

            Application.logMessageReceived += Application_logMessageReceived;
            pluginInstance.CallStatic("receiveUnityActivity", unityActivity);

            CreateAlert();
            Debug.Log("Unity Java Class Created");
        }
    }

    private void Application_logMessageReceived(string condition, string stacktrace, LogType type)
    {
        pluginInstance.Call("SendLog", condition);
        SendToWrite(condition, LogType.Log);
    }

    public void CreateLog(string message)
    {
        string data = "";
        LogType currentLog = LogType.Log;
        Debug.Log("Debug Log - " + message);
        currentLog = LogType.Log;
        data = "Debug Log - " + message;
        SendToWrite(data, currentLog);
        SendToReadFile();
    }

    public void SendToWrite(string data, LogType fileType)
    {
        pluginInstance.Call("writeToFile", "Logs.txt", data);
    }

    public void SendToReadFile()
    {
        string temp;
        temp = pluginInstance.Call<string>("readFromFile", "Logs.txt");
        tempArray = temp.Split("\n");
        for (int i = 0; i < tempArray.Length; i++)
        {
            GameObject newText = Instantiate(textObject, textPanel.transform);
            newText.GetComponent<TextMeshProUGUI>().text = tempArray[i];
            createdLogs.Add(newText);
        }
    }

    public void CreateAlert()
    {
        Debug.Log("Unity Alert Created");
        pluginInstance.Call("CreateAlert", new AndroidPluginCallback { });
        SendToReadFile();
    }

    public void ShowAlert()
    {
        Debug.Log("Unity Alert Show");
        pluginInstance.Call("ShowAlert");
        SendToReadFile();
        for (int i = 0; i < createdLogs.Count; i++)
        {
            Destroy(createdLogs[i].gameObject);
        }
        createdLogs.Clear();
    }

    [ContextMenu("Test msg")]
    private void TestMsg()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject newText = Instantiate(textObject, textPanel.transform);
            newText.GetComponent<TextMeshProUGUI>().text = "Test msg" + i;
            createdLogs.Add(newText);
            Debug.Log("Test msg" + i);
        }
    }
#endif
}
