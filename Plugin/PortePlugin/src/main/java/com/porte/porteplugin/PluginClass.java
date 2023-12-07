package com.porte.porteplugin;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.util.Log;
import android.widget.Toast;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class PluginClass
{
    private static String LOGTAG = "OKAMILOG";
    private static Activity unityActivity;
    static PluginClass instance = null;
    AlertDialog.Builder builder;
    List<String> logs = new ArrayList<>();
    public String filename;

    public static  PluginClass getInstance()
    {
        if ( instance == null)
        {
            instance = new PluginClass();
        }

        return instance;
    }
    public static void receiveUnityActivity(Activity tActivity)
    {
        unityActivity = tActivity;
    }

    public void CreateAlert(AlertCallBack alertCallBack)
    {
        builder = new AlertDialog.Builder(unityActivity);
        builder.setMessage("Do you want to delete the log file?");
        builder.setCancelable(true);
        builder.setPositiveButton("Yes", new DialogInterface.OnClickListener()
        {
            @Override
            public void onClick(DialogInterface dialogInterface, int i)
            {
                Log.v(LOGTAG, "Clicked - YES");
                alertCallBack.onPositive("Click on yes");
                DeleteLogFile();
                dialogInterface.cancel();
            }
        });

        builder.setNegativeButton("No", new DialogInterface.OnClickListener()
        {
            @Override
            public void onClick(DialogInterface dialogInterface, int i)
            {
                Log.v(LOGTAG, "Clicked - NO");
                alertCallBack.onNegative("Click on no");
                dialogInterface.cancel();
            }
        });
    }

    public void ShowAlert()
    {
        AlertDialog alert = builder.create();
        alert.show();
    }

    public void SendLog(String log)
    {
        this.logs.add(log);
        Log.v(LOGTAG,"Android Added debug Log - " + log);
    }

    private void writeToFile(String fileName,String data)
    {
        this.filename = fileName;
        Context context = unityActivity.getApplicationContext();
        File file = new File(context.getExternalFilesDir(null),fileName);
        Log.v("FileWriter", context.getExternalFilesDir(null).toString());
        try
        {
            FileWriter fileWriter = new FileWriter(file, true);
            for (int i = 0; i < logs.size(); i++)
            {
                fileWriter.append(logs.get(i)).append("\n");
            }
            fileWriter.close();
        }
        catch (IOException e) {
            Log.e("Exception", "File write failed: " + e.toString());
        }
    }

    private String readFromFile(String fileName)
    {
        Context context = unityActivity.getApplicationContext();
        File readFrom = new File(context.getExternalFilesDir(null),fileName);
        Log.v("FileReader", context.getExternalFilesDir(null).toString());
        byte[] content = new byte[(int)readFrom.length()];
        try
        {
            FileInputStream inputStream =  new FileInputStream(readFrom);
            inputStream.read(content);
            return new String(content);
        }
        catch (FileNotFoundException e)
        {
            Log.e("login activity", "File not found: " + e.toString());
            Toast.makeText(unityActivity.getApplicationContext(),"File not found: " + filename,Toast.LENGTH_SHORT).show();
            return e.toString();
        } catch (IOException e)
        {
            Log.e("login activity", "Can not read file: " + e.toString());
            Toast.makeText(unityActivity.getApplicationContext(),"Can not read file: " + filename,Toast.LENGTH_SHORT).show();
            return e.toString();
        }
    }

    public void DeleteLogFile()
    {
        Context context = unityActivity.getApplicationContext();
        File logFile = new File(context.getExternalFilesDir(null), filename);
        if (logFile.exists())
        {
            if (logFile.delete());
            Toast.makeText(unityActivity.getApplicationContext(),"The file : " + filename + " has been deleted",Toast.LENGTH_SHORT).show();
        }
        else
        {
            Toast.makeText(unityActivity.getApplicationContext(),"The file : " + filename + " does not exist",Toast.LENGTH_SHORT).show();
        }
    }
}
