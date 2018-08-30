using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : FSMState
{
    public Right(FSM fsm) : base(fsm)
    {
        stateID = StateID.Right;
        InitState();
    }

    public override void InitState()
    {
        base.InitState();
        AddTransition(TransitionID.Down, StateID.Down);
        AddTransition(TransitionID.Up, StateID.Up);
        AddTransition(TransitionID.Left, StateID.Left);
    }

}
