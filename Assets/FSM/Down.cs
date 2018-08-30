using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : FSMState
{
    public Down(FSM fsm) : base(fsm)
    {
        stateID = StateID.Down;
        InitState();
    }

    public override void InitState()
    {
        base.InitState();
        AddTransition(TransitionID.Up, StateID.Up);
        AddTransition(TransitionID.Left, StateID.Left);
        AddTransition(TransitionID.Right, StateID.Right);
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("InDwoning");
    }
}
