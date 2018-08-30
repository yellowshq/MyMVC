using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class HqGameEvent : IEvent
{
    //public bool IsDispose
    //{
    //    get;
    //}

    protected Dictionary<Enum, List<EventHandler>> mEventDic=new Dictionary<Enum, List<EventHandler>>();
    protected Dictionary<Enum, List<EventHandler>> mUseOnceEventDic=new Dictionary<Enum, List<EventHandler>>();

    public void AddEvent(Enum e, EventHandler handler)
    {
        if (!mEventDic.ContainsKey(e))
        {
            List<EventHandler> eventHandlers = new List<EventHandler>();
            eventHandlers.Add(handler);
            mEventDic.Add(e, eventHandlers);
        }
        else
        {
            List<EventHandler> eventHandlers;
            if(mEventDic.TryGetValue(e,out eventHandlers))
            {
                eventHandlers.Add(handler);
            }
            else
            {
                Debug.Log("unknown error!");
            }
        }
    }

    public void DispatchEvent(Enum e, params object[] args)
    {
        if (HasEvent(e))
        {
            foreach (var handler in mEventDic[e])
            {
                handler(args);
            }
        }
        else
        {
            Debug.Log(e + "is not register");
        }

    }

    public void RemoveEvent(Enum e)
    {
        if (HasEvent(e))
        {
            mEventDic.Remove(e);
        }
        else
        {
            Debug.Log("no key to remove");
        }
    }

    public void RemoveEvent(Enum e, EventHandler handler)
    {
        List<EventHandler> handlers;
        if (HasEvent(e))
        {
            handlers = mEventDic[e];
            handlers.Remove(handler);
            if (handlers.Count == 0)
            {
                RemoveEvent(e);
            }
        }
    }

    public bool HasEvent(Enum e)
    {
        return mEventDic.ContainsKey(e);
    }


}
