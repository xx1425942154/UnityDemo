using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;




public class CommandTool 
{

    [MenuItem("Tool/CopyShell")]
    static void CopyShell()
    {
        /* string shell = Path.Combine(Application.dataPath,"copy.sh");
         int arg1 = 10000;
         string argss = $"{shell} {arg1}";
         Debug.LogFormat("begin : {0}", System.DateTime.Now.ToString("hh:mm:ss").ToString());
         System.Diagnostics.Process.Start("/bin/bash",argss).WaitForExit();
         Debug.LogFormat("end : {0}", System.DateTime.Now.ToString("hh:mm:ss").ToString());*/
        string shell = System.IO.Path.Combine(Application.dataPath, "Build.sh");
        System.Diagnostics.Process.Start("/bin/bash", shell);

    }
}
