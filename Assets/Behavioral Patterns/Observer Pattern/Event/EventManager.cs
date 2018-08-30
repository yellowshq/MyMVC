using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : BaseEvent
{
    //TO 
    private static EventManager eventManager = null;
    public static EventManager Instance
    {
        private set { }
        get
        {
            if (eventManager == null)
            {
                eventManager = new EventManager();
            }
            return eventManager;
        }
    }
}
