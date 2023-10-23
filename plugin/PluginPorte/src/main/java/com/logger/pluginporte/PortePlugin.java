package com.logger.pluginporte;

import android.util.Log;
import java.util.ArrayList;
import java.util.List;

public class PortePlugin {

    static PortePlugin _instance = new PortePlugin();
    static final String LOGTAG = "OKAMILOGG";

    public static PortePlugin GetInstance()
    {
        if (_instance == null)
            _instance = new PortePlugin();
        return _instance;
    }
    private long startTime;
    private PortePlugin()
    {
        Log.i(LOGTAG, "Create Plugin");
        startTime = System.currentTimeMillis();
    }

    public double GetElapsedTime()
    {
        return (System.currentTimeMillis() - startTime) / 1000.0f;
    }

    List<String> logList = new ArrayList<String>();

    public String GetLOGTAG()
    {
        return LOGTAG;
    }

    public void SendLog(String log)
    {
        logList.add(log);
    }

}