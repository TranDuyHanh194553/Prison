using System;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace UnityTools.EditorUtility
{
    public static class AssetGit
    {
        private const string MenuAssetPath = "Assets/Tools/";
        private const int Priority = 1000;

        private static string WrapQuote(string s)
        {
            return "'" + s + "'";
        }
        
        
        [MenuItem(MenuAssetPath + "Add to git %#0", false, Priority)]
        private static void AddToGit()
        {
            var guids = Selection.assetGUIDs;
 

            foreach (string guid in guids)
            { 
                var assetPath = AssetDatabase.GUIDToAssetPath(guid); 
                var metaPath = AssetDatabase.GetTextMetaFilePathFromAssetPath(assetPath);
                Debug.Log("add asset to git: " + assetPath + ", meta: " + metaPath);
                
                // RunGitCommand("add " + assetPath);
                var result = RunGitCommand(" "+ "add " + "-f " + WrapQuote(assetPath) + " " + WrapQuote(metaPath));
                Debug.Log("git command result: " + result);
            }
            
        }
 
        [MenuItem(MenuAssetPath + "Add to git %#0", true, Priority)]
        private static bool AddToGitValidation()
        {
            return Selection.assetGUIDs.Length >= 1;
        }
        
        public static string RunGitCommand(string gitCommand) {
            // Strings that will catch the output from our process.
            string output = "no-git";
            string errorOutput = "no-git";

            // Set up our processInfo to run the git command and log to output and errorOutput.
            ProcessStartInfo processInfo = new ProcessStartInfo("git", @gitCommand) {
                CreateNoWindow = true,          // We want no visible pop-ups
                UseShellExecute = false,        // Allows us to redirect input, output and error streams
                RedirectStandardOutput = true,  // Allows us to read the output stream
                RedirectStandardError = true    // Allows us to read the error stream
            };

            // Set up the Process
            Process process = new Process {
                StartInfo = processInfo
            };

            try {
                process.Start();  // Try to start it, catching any exceptions if it fails
            } catch (Exception e) {
                // For now just assume its failed cause it can't find git.
                Debug.LogError("Git is not set-up correctly, required to be on PATH, and to be a git project.");
                throw e;
            }

            // Read the results back from the process so we can get the output and check for errors
            output = process.StandardOutput.ReadToEnd();
            errorOutput = process.StandardError.ReadToEnd();

            process.WaitForExit();  // Make sure we wait till the process has fully finished.
            process.Close();        // Close the process ensuring it frees it resources.

            // Check for failure due to no git setup in the project itself or other fatal errors from git.
            if (output.Contains("fatal") || output == "no-git") {
                throw new Exception("Command: git " + @gitCommand + " Failed\n" + output + errorOutput);
            }
            // Log any errors.
            if (errorOutput != "") {
                Debug.LogError("Git Error: " + errorOutput);
            }

            return output;  // Return the output from git.
        }
        
    }
}
 