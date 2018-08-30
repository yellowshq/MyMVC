using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMainGame : MonoBehaviour
{

    void Awake()
    {
        /* TODO 游戏加载流程;
         * 1.绑定unity脚本(管理类);
         * 2.初始化战斗系统代码;
         * 3.1初始化公共资源_(公共资源配置表);
         * 3.2初始化公共资源(实体资源);
         * 4.初始化配置表;
         * 5.初始化各个功能模块;
         */


        RegisterMoudle();

    }

    private void Start()
    {
        HqGlobalEvent.Instance.DispatchEvent(GameEnumEvent.TestShow);
    }
    /// <summary>
    /// 初始化各个功能模块5;
    /// </summary>
    private void RegisterMoudle()
    {
        Facade.Instance.RegisterController<TestController>();
    }
}
