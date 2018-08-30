using UnityEngine;
using System.Collections;
using System;

public delegate void EventHandler(params object[] args);
public interface IEvent 
{
   // bool IsDispose { get; }

    void AddEvent(Enum e, EventHandler handler);
    void DispatchEvent(Enum e, params object[] args);
    void RemoveEvent(Enum e);
    void RemoveEvent(Enum e, EventHandler handler);
    bool HasEvent(Enum e);
}
