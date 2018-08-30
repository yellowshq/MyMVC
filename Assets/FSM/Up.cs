using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : FSMState
{
    public Up(FSM fsm) : base(fsm)
    {
        stateID = StateID.Up;
        InitState();
    }

    public override void InitState()
    {
        base.InitState();
        AddTransition(TransitionID.Down, StateID.Down);
        AddTransition(TransitionID.Left, StateID.Left);
        AddTransition(TransitionID.Right, StateID.Right);
    }
}

