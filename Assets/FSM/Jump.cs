using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : FSMState
{
    public Jump(FSM fsm) : base(fsm)
    {
        stateID = StateID.Jump;
        InitState();
    }

    public override void InitState()
    {
        base.InitState();
        AddTransition(TransitionID.Down, StateID.Down);
        AddTransition(TransitionID.Up, StateID.Up);
        AddTransition(TransitionID.Left, StateID.Left);
        AddTransition(TransitionID.Right, StateID.Right);
    }
}

