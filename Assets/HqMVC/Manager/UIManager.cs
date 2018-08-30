using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShowType
{
    Normal, //普通显示-显示在上一个窗体的上层：
    ReverseChange,
    HideOther,//显示时隐藏其他窗口;
}

public enum WindownType
{
    Normal, //普通窗口;
    Fixed,  //固定窗口;
    Popup,  //弹出窗口;
}
public class UIManager : MonoBehaviour
{

    private static UIManager _Instance = null;
    /// <summary>
    /// 正在显示的窗口;
    /// </summary>
    public Dictionary<string, View> AllCacheViews = new Dictionary<string, View>();

    Transform UIRoot;
    Transform Normal;
    Transform Fixed;
    Transform Popup;
    /// <summary>
    /// 得到实例
    /// </summary>
    /// <returns></returns>
    public static UIManager GetInstance()
    {
        if (_Instance == null)
        {
            _Instance = new GameObject("UIManager").AddComponent<UIManager>();
        }
        return _Instance;
    }

    private void Awake()
    {
        CreateUIBase();
        DontDestroyOnLoad(gameObject);
    }

    public void ShowView(string viewName, CallBack<View> loadComplete)
    {
        //TODO 加载窗口;AssetManager]
        View view;
        if (!IsShow(viewName))
        {
            GameObject viewObj = AssetManager.LoadView(viewName);
            view = viewObj.GetComponent<View>();
            AllCacheViews.Add(viewName, view);
            GameObject viewins =Instantiate(viewObj);
            switch (view.windowType)
            {
                case WindownType.Normal:
                    viewins.transform.SetParent(Normal);
                    break;
                case WindownType.Fixed:
                    viewins.transform.SetParent(Fixed);
                    break;
                case WindownType.Popup:
                    viewins.transform.SetParent(Popup);
                    break;
            }
        }
        else
        {
            view = AllCacheViews[viewName];
        }
        loadComplete(view);
        view.OnShow();
    }

    private void CreateUIBase()
    {
        UIRoot = GameObject.Find("UIRoot").transform;
        if (UIRoot!=null)
        {
            Normal = new GameObject("Normal").AddComponent<RectTransform>();
            Normal.localPosition = Vector3.zero;
            Normal.SetParent(UIRoot);
            Fixed = new GameObject("Fixed").AddComponent<RectTransform>();
            Fixed.localPosition = Vector3.zero;
            Fixed.SetParent(UIRoot);
            Popup = new GameObject("Popup").AddComponent<RectTransform>();
            Popup.localPosition = Vector3.zero;
            Popup.SetParent(UIRoot);
        }
    }

    public bool IsShow(string viewName)
    {
        return AllCacheViews.ContainsKey(viewName);
    }
}
