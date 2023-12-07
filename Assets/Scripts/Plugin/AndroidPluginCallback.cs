using System;
using UnityEngine;

public class AndroidPluginCallback : AndroidJavaProxy
{
    public AndroidPluginCallback() : base("com.porte.porteplugin.AlertCallBack") 
    {

    }

    public void onPositive(String message)
    {
        Debug.Log("On Unity Positive - " + message);
    }

    public void onNegative(String message)
    {
        Debug.Log("On Unity Negative - " + message);
    }
}
