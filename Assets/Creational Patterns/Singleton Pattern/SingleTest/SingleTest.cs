using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        SingleATest.Instance.DebugL();

        Debug.Log(GetCurSourceFileName() + ":" + GetLineNum());
    }
    /// 取得当前源码的哪一行
    /// </summary>
    /// <returns></returns>
    public static int GetLineNum()
    {
        System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(1, true);
        return st.GetFrame(0).GetFileLineNumber();
    }

    /// <summary>
    /// 取当前源码的源文件名
    /// </summary>
    /// <returns></returns>
    public static string GetCurSourceFileName()
    {
        System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(1, true);

        return st.GetFrame(0).GetFileName();

    }
}

public abstract class SingBase<T> where T : class, new()
{
    private static T _instance = null;
    public static T Instance
    {
        get
        {
            if (_instance == null)
                _instance = new T();
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        _instance = this as T;
    }
}

public class SingleATest : SingBase<SingleATest>
{
    public void DebugL()
    {
        Debug.Log(this.GetType());
    }
}
