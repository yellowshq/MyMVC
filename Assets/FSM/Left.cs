using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : FSMState {

    public Left(FSM fsm) : base(fsm)
    {
        stateID = StateID.Left;
        InitState();
    }

    public override void InitState()
    {
        base.InitState();
        AddTransition(TransitionID.Down, StateID.Down);
        AddTransition(TransitionID.Up, StateID.Up);
        AddTransition(TransitionID.Right, StateID.Right);
    }

}
