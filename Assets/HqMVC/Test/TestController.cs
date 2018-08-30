using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : Controller {

    public TestController(Type type) : base(type,GameEnumEvent.TestShow,GameEnumEvent.TestClose)
    {
        base.SetModel<TestModel>();
    }

    public void Register()
    {
        Debug.Log("TestController");
    }
}
