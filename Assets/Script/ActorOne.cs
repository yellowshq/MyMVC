using UnityEngine;
using System.Collections;

public class ActorOne  : BaseGameEntity {
	
	StateMachine<ActorOne> m_pStateMachine;
	
	
	public Transform TwoTransform;
	
	public Vector3 oriV3;
	
	public bool isBackToPosition;
	// Use this for initialization
	void Start () {
		isBackToPosition =false;
		// set id 
		SetID((int)EntityID.m_ActorOne);
		
		m_pStateMachine = new StateMachine<ActorOne>(this);
//		
		m_pStateMachine.SetCurrentState(ActorOne_StateOne .Instance());	

		m_pStateMachine.SetGlobalStateState(ActorOne_GloballState .Instance());

		EntityManager.Instance().RegisterEntity(this);
	}
	
	void Update ()
	{	
		
		m_pStateMachine.SMUpdate();
	}

	public StateMachine<ActorOne> GetFSM ()
	{
		return m_pStateMachine;
	}
	
	public override bool HandleMessage (Telegram telegram)
	{
		
		
		return 	m_pStateMachine.HandleMessage(telegram);

	}
}
