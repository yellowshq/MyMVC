using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HqGlobalEvent : HqGameEvent {

    private static HqGlobalEvent _instance = null;
    
    public static HqGlobalEvent Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new HqGlobalEvent();
            }
            return _instance;
        }
    }
}
