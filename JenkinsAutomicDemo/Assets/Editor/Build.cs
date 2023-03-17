using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Build 
{

    [MenuItem("Tool/BuildPC")]
    static void BuildPC()
    {

        /*  foreach (string arg in System.Environment.GetCommandLineArgs())
          {
              Debug.Log($"arg = {arg}");


          }*/
       
        Dictionary<string, string> args = GetArgs("Build.BuildPC");
        if (args.Count == 0) Debug.Log("arg = null"); return;
       // PlayerSettings.bundleVersion = args["version"];
       // PlayerSettings.productName = args["name"];
        BuildPipeline.BuildPlayer(GetBUildScenes(), args["out"],BuildTarget.StandaloneWindows64,BuildOptions.Development);
    }



    static string[] GetBUildScenes()
    {
        List<string> names = new List<string>();


        foreach (EditorBuildSettingsScene e in EditorBuildSettings.scenes)
        {
            if (e == null) continue;
            if (e.enabled) names.Add(e.path);
        }
        return names.ToArray();
    }




    static Dictionary<string, string> GetArgs(string methodName)
    {

        Dictionary<string, string> args = new Dictionary<string, string>();
        bool isArg = false;
        foreach (string arg in System.Environment.GetCommandLineArgs())
        {
            Debug.Log($"arg = {arg} isArg = {isArg}");
            if (isArg)
            {
                Debug.Log("进来没");
                if (arg.StartsWith("__"))
                {
                    int splitIndex = arg.IndexOf("=");
                    if (splitIndex > 0)
                    {
                        Debug.Log("存在自定义参数 并解析");
                        args.Add(arg.Substring(2, splitIndex - 2), arg.Substring(splitIndex + 1));

                    }
                    else
                    {
                        Debug.Log("不存在自定义参数 默认解析");
                        args.Add(arg.Substring(2), "true");
                    }
                }
            }
            else if (arg == methodName)
            {
                isArg = true;
            }
        }
        return args;
    }

}
