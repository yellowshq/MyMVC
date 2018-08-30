using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : IDisposable
{
    public string viewName;
    public View view;
    public Model model;

    public Enum showevent;
    public Enum closeevent;

    public Controller() { }

    public Controller(Type viewType)
    {
        viewName = viewType.FullName;
    }

    public Controller(Type viewType, Enum showevent, Enum closeevent)
    {
        viewName = viewType.FullName;
        this.showevent = showevent;
        this.closeevent = closeevent;
        if (!HqGlobalEvent.Instance.HasEvent(showevent))
        {
            HqGlobalEvent.Instance.AddEvent(showevent, OnPreShow);
        }
        if (!HqGlobalEvent.Instance.HasEvent(closeevent))
        {
            HqGlobalEvent.Instance.AddEvent(closeevent, OnClose);
        }
    }

    public virtual void OnPreShow(params object[] args)
    {
        UIManager.GetInstance().ShowView(viewName, (view) => { this.view = view; });
    }

    public virtual void OnClose(params object[] args)
    {
        Debug.Log("OnClose");
    }

    public virtual void Init()
    {

    }

    public virtual void SetModel<T>() where T : Model, new()
    {
        model = new T() as Model;
    }

    public virtual T GetModel<T>() where T : Model
    {
        return model as T;
    }

    public virtual T GetView<T>() where T : View
    {
        return view as T;
    }

    #region IDisposable Support
    private bool disposedValue = false; // 要检测冗余调用

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: 释放托管状态(托管对象)。
            }

            // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
            // TODO: 将大型字段设置为 null。

            disposedValue = true;
        }
    }

    // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
    // ~Controller() {
    //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
    //   Dispose(false);
    // }

    // 添加此代码以正确实现可处置模式。
    public void Dispose()
    {
        // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        Dispose(true);
        // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
        // GC.SuppressFinalize(this);
    }
    #endregion
}
