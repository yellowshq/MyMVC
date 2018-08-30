using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour {
    private void Awake()
    {
        EventManager.Instance.AddListener("Debug", GameEvent);
    }

    //private void DebugFunc(object[] args)
    //{
    //    Debug.Log("DebugFunc Called");
    //}

    void Start () {
        EventManager.Instance.Dispatch("Debug",1);
    }
	
	// Update is called once per frame
	void Update () {
    
    }

    void GameEvent(EventData eventData)
    {
        Debug.Log((int)eventData.param);
    }
}
