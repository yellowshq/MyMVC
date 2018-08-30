using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour,IDisposable {

    public string viewName;
    public ShowType showType = ShowType.Normal;
    public WindownType windowType = WindownType.Normal;
    protected virtual void Init()
    {

    }

    protected virtual void Awake()
    {

    }

    protected virtual void Start () {
		
	}
	
	protected virtual void Update () {
		
	}


    public virtual void OnShow()
    {
        
    }

    public virtual void Show()
    {
        
    }

    public virtual void Hide()
    {

    }

    public virtual void Destory()
    {
    }

    public virtual void Dispose()
    {
        
    }

}
