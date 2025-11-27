using System.Linq;
using UnityEditor;
using UnityEngine;

public class InitBundle
{
    [MenuItem("Assets/BuildBundleAndroid")]
    static void BuildAssetBundle()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.Android);
    }

    [MenuItem("Assets/BuildBundle")]
    static void BuildAssetBundlePC()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
    
    [MenuItem("Assets/ClearCache")]
    static void Clearing()
    {
        Caching.ClearCache();
    }


    }
