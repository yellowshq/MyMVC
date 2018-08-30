using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateID
{
    Down,
    Up,
    Left,
    Right,
    Jump,
}
public enum TransitionID
{
    Down,
    Up,
    Left,
    Right,
    Jump,
}
public abstract class FSMState {

    public StateID stateID { get; set; }

    public Dictionary<TransitionID, StateID> transitionPairs = new Dictionary<TransitionID, StateID>();

    protected FSM fsm;

    public FSMState(FSM fsm)
    {
        this.fsm = fsm;
    }

    public virtual void InitState()
    {
        fsm.transitionPairs.Add(this.stateID, this);
    }

    public virtual void EnterState()
    {
        Debug.Log("EnterState:"+this.GetType());
    }

    public virtual void Excute()
    {
        Debug.Log("Excute:" + this.GetType());
    }

    public virtual void ExitState()
    {
        Debug.Log("ExitState:" + this.GetType());
    }

    public virtual void Update()
    {

    }

    protected void AddTransition(TransitionID transitionID,StateID stateID)
    {
        if (transitionPairs.ContainsKey(transitionID))
        {
            Debug.Log("条件转换表中已存在该条件!");
        }
        else
        {
            transitionPairs.Add(transitionID, stateID);
        }
    }
}
