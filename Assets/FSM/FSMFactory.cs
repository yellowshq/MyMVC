using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMFactory{

    private static FSMFactory _instance = null;
    private static object o=new object();
    public static FSMFactory Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (o)
                {
                    if (_instance == null)
                    {
                        _instance = new FSMFactory();
                    }
                }
            }
            return _instance;
        }
    }

    private FSMFactory() { }
   
    public FSMState CreateState(FSM fsm,string stateName)
    {
        FSMState state = null;
        if (stateName.Equals("Down"))
        {
            state = new Down(fsm);
        }else if (stateName.Equals("Up"))
        {
            state = new Up(fsm);
        }
        else if (stateName.Equals("Left"))
        {
            state = new Left(fsm);
        }
        else if (stateName.Equals("Right"))
        {
            state = new Right(fsm);
        }
        else if (stateName.Equals("Jump"))
        {
            state = new Jump(fsm);
        }
        return state;
    }
}
