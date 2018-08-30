using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM {

    public FSMState currentState { get; set; }

    public Dictionary<StateID, FSMState> transitionPairs = new Dictionary<StateID, FSMState>();

    public void Start()
    {

    }

    public void Transition(TransitionID transitionID)
    {
        var tempT = currentState.transitionPairs;
        StateID stateID;
        if(tempT.TryGetValue(transitionID, out stateID))
        {
            FSMState state;
            if(transitionPairs.TryGetValue(stateID, out state))
            {
                currentState.ExitState();
                state.EnterState();
                state.Excute();
                currentState = state;
            }
            else
            {
                Debug.Log("无法转换到下一个状态,因为State不存在!");
            }
        }
        else
        {
            Debug.Log("无法转换到下一个状态,因为StateID不存在!");
        }

    }

}
