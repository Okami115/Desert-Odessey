package com.logger.pluginporte;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.util.Log;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class PortePlugin {

    static PortePlugin _instance = new PortePlugin();
    public static PortePlugin GetInstance()
    {
        if (_instance == null)
            _instance = new PortePlugin();
        return _instance;
    }

    static final String LOGTAG = "OKAMILOG";
    private static Activity unityActivity;
    AlertDialog.Builder builder;
    public String filename;
    List<String> warnings = new ArrayList<>();
    List <String> errors = new ArrayList<>();
    List <String> debug = new ArrayList<>();

    public static void reciveUnityActivity(Activity uActivity)
    {
        unityActivity = uActivity;
    }

    public void CreateAlert(AlertCallback alertCallback)
    {
        Log.v(LOGTAG,"Android Create Alert");
        builder = new AlertDialog.Builder(unityActivity);
        builder.setMessage("Do you want to delete the log file?");
        builder.setCancelable(false);
        builder.setPositiveButton(
                "Yes",
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        Log.v(LOGTAG,"Clicked From Pluggin - YES");
                        alertCallback.onPositive("Clicked Yes");
                        DeleteLogFile();
                        dialogInterface.cancel();
                    }
                }
        );
        builder.setNegativeButton(
                "No",
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        Log.v(LOGTAG,"Clicked From Pluggin - NO");
                        alertCallback.onNegative("Clicked NO");
                        dialogInterface.cancel();
                    }
                }
        );
    }

    public void ShowAlert()
    {
        Log.v(LOGTAG,"Android Show Alert");
        AlertDialog alert = builder.create();
        alert.show();
    }

    public void SendLog(String log)
    {
        this.debug.add(log);
        Log.v(LOGTAG,"Android Added debug Log - " + log);
    }

    public void SendWarning(String warning)
    {
        this.warnings.add(warning);
        Log.v(LOGTAG,"Android Added warning Log - " + warning);
    }

    public void SendError(String error)
    {
        this.errors.add(error);
        Log.v(LOGTAG,"Android Added error Log - " + error);
    }

    public String GetLOGTAG()
    {
        return LOGTAG;
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
            for (int i = 0; i < debug.size(); i++)
            {
                fileWriter.append(debug.get(i)).append("\n");
            }
            for (int i = 0; i < warnings.size(); i++)
            {
                fileWriter.append(warnings.get(i)).append("\n");
            }
            for (int i = 0; i < errors.size(); i++)
            {
                fileWriter.append(errors.get(i)).append("\n");
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