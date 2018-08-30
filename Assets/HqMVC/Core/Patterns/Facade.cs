using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facade{
    private static Facade m_instance = null;

    private static readonly object m_staticSyncRoot;
    public static Facade Instance
    {
        get
        {
            if (m_instance == null)
            {
                lock (m_staticSyncRoot)
                {
                    if (m_instance == null)
                    {
                        m_instance = new Facade();
                    }
                }
            }
            return m_instance;
        }
    }

    private Dictionary<Type, Model> modelPairs = new Dictionary<Type, Model>();
    private Dictionary<Type, View> viewPairs = new Dictionary<Type, View>();
    private Dictionary<Type, Controller> controllerPairs = new Dictionary<Type, Controller>();
    static Facade()
    {
        m_staticSyncRoot = new object();
    }

    public void RegisterModel(Type t,Model m)
    {
        if (!modelPairs.ContainsKey(t))
        {
            modelPairs.Add(t, m);
        }
    }

    public T GetModel<T>() where T:Model
    {
        Model model;
        if (modelPairs.TryGetValue(typeof(T), out model))
        {
            if(model is T)
            {
                return model as T;
            }
        }
        return null;
    }

    public void RegisterController(Type t, Controller c)
    {
        if (!controllerPairs.ContainsKey(t))
        {
            controllerPairs.Add(t, c);
        }
    }

    public T RegisterController<T>() where T : Controller
    {
        return registerController(typeof(T)) as T;
    } 

    public Controller registerController(Type type)
    {
        if (!controllerPairs.ContainsKey(type))
        {
            Controller ctrl = InstantiateC(type);
            controllerPairs.Add(type, ctrl);
            return ctrl;
        }
        return null;
    }

    private Controller InstantiateC(Type type)
    {

        string ctrlName = type.FullName;
        Type tc = Type.GetType(ctrlName);
        if (tc != null)
        {
            System.Object[] parameters = new System.Object[1];
            parameters[0] = Type.GetType(ctrlName.Replace("Controller","")+"View");
            Controller controller = tc.Assembly.CreateInstance(ctrlName, true, System.Reflection.BindingFlags.Default, null, parameters, null, null) as Controller;
            return controller;
        }
        return null;
    }

    public T GetController<T>() where T : Controller
    {
        Controller controller;
        if (controllerPairs.TryGetValue(typeof(T), out controller))
        {
            if(controller is Controller)
            {
                return controller as T;
            }
        }
        return null;
    }

    //框架入口函数;
    public void Startup()
    {

    }
}
