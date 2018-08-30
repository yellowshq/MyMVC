using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMStateTest : MonoBehaviour {

    FSM fsm;
	void Start () {
        fsm = new FSM();

        FSMState down =FSMFactory.Instance.CreateState(fsm,"Down");
        FSMState up = FSMFactory.Instance.CreateState(fsm, "Up");
        FSMState Right = FSMFactory.Instance.CreateState(fsm, "Right");
        FSMState Left = FSMFactory.Instance.CreateState(fsm, "Left");
        fsm.currentState = down;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            fsm.Transition(TransitionID.Up);
        }else if (Input.GetKeyDown(KeyCode.S))
        {
            fsm.Transition(TransitionID.Down);
        }else if (Input.GetKeyDown(KeyCode.A))
        {
            fsm.Transition(TransitionID.Left);
        }else if (Input.GetKeyDown(KeyCode.D))
        {
            fsm.Transition(TransitionID.Right);
        }
        fsm.currentState.Update();
	}
}
