using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventData
{
    public object param { get; set; }
    public EventData(object param)
    {
        this.param = param;
    }
}

public abstract class BaseEvent{

    public delegate void GameEventCallBack(EventData eventData);
    //public delegate void GameEventCallBack(T arg1);
    //public delegate void GameEventCallBack();
    //public delegate void GameEventCallBack();
    protected Dictionary<object, GameEventCallBack> eventDictionary = new Dictionary<object, GameEventCallBack>();
    public virtual void AddListener(object o, GameEventCallBack e)
    {
        if (eventDictionary.ContainsKey(o))
        {
            Debug.Log("this key is Exist:" + o.ToString());
            return;
        }
        eventDictionary.Add(o, e);
    }
    //public virtual void AddListener<T>(object o,Action<T> a)
    //{
    //    AddToDic(o, a);
    //}
    //public virtual void AddListener(object o,Func<object> f)
    //{
    //    AddToDic(o, f);
    //}
    //public virtual void AddListener<T>(object o, Func<T,object> f)
    //{
    //    AddToDic(o, f);
    //}
    public virtual void Dispatch(object o,params object[] args)
    {
        GameEventCallBack func;
        if(eventDictionary.TryGetValue(o,out func))
        {
            EventData eventData = new EventData(args[0]);
            func(eventData);
        }
        else
        {
            Debug.Log("Dispath Wrong!");
        }
    }
}
