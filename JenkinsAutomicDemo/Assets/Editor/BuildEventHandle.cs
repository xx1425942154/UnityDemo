using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Build;
using UnityEditor;
using System.IO;

public class BuildEventHandle : IPreprocessBuild, IPostprocessBuild
{
    

    int IOrderedCallback.callbackOrder => 0;


    public void OnPreprocessBuild(BuildTarget target, string path)
    {

        PlayerSettings.bundleVersion = "1.0.0";
        PlayerSettings.productName = "jenkinsAutomicDemo";
        string data = Path.Combine(Path.GetDirectoryName(path),$"{Path.GetFileNameWithoutExtension(path)}_Data");

        if (File.Exists(path)) File.Delete(path);
        if (File.Exists(data)) File.Delete(data);
    }  

    void IPostprocessBuild.OnPostprocessBuild(BuildTarget target, string path)
    {
        Debug.LogFormat("游戏包生成路径:{0}",path);
        string data = Path.Combine(Path.GetDirectoryName(path), $"{Path.GetFileNameWithoutExtension(path)}_Data");
        string zip = Path.Combine(Path.GetDirectoryName(path),"project.zip");


        if (File.Exists(zip)) File.Delete(zip);

        System.Diagnostics.Process process = new System.Diagnostics.Process();
        process.StartInfo.FileName = "osascript";
        process.StartInfo.Arguments = $"-e 'tell application \"Terminal\"to do script \"zip -r {zip} {path} {data}\"'";

        process.Start();
        process.WaitForExit();
        process.Close();



    }
}
