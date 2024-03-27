using System;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace UnityTools.EditorUtility
{
    public static class AssetDebug
    {
        private const string MenuAssetPath = "Assets/Tools/";
        private const int Priority = 3000;
        
        [MenuItem(MenuAssetPath + "Debug guid %#0", false, Priority)]
        private static void AddToGit()
        {
            var guids = Selection.assetGUIDs;
            var assetPath = AssetDatabase.GUIDToAssetPath(guids[0]);
            var metaPath = AssetDatabase.GetTextMetaFilePathFromAssetPath(assetPath);
            Debug.Log("Asset guid: " + guids[0] + ",path: " + assetPath + ", meta: " + metaPath);
            
        }
 
        [MenuItem(MenuAssetPath + "Debug guid %#0", true, Priority)]
        private static bool AddToGitValidation()
        {
            return Selection.assetGUIDs.Length == 1;
        }
        
        
    }
}
 