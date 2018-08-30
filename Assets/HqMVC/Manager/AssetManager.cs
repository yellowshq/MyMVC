using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager{



	public static T LoadResource<T>(string path) where T:UnityEngine.Object
    {
       T res = Resources.Load<T>(path);
        if (res == null)
        {
            Debug.Log("load resources failed:" + path);
        }
        return res;
    }

    public static GameObject LoadPrefab(string path,string name = "")
    {
        if (string.IsNullOrEmpty(name))
        {
            name = path;
        }
        string loadPath = Path.PrefabPath + "/" + path + "/" + name;
        GameObject res = LoadResource<GameObject>(loadPath);
        return GameObject.Instantiate<GameObject>(res);
    }

    public static GameObject LoadView(string path, string name = "")
    {
        if (string.IsNullOrEmpty(name))
        {
            name = path;
        }
        string loadPath = Path.PrefabPath + "/" + path + "/" + name;
        GameObject res = LoadResource<GameObject>(loadPath);

        return res;
    }
}
