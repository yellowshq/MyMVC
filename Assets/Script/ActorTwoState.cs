using UnityEngine;
using System.Collections;

public class ActorTwo_GloballState : State<ActorTwo>
{
	private static ActorTwo_GloballState instance;
	public static ActorTwo_GloballState Instance ()
	{
		if (instance == null)
			instance = new ActorTwo_GloballState ();
		
		return instance;
	}


	public override void Enter (ActorTwo Entity)
	{
		
		
		
	}

	public override void Execute (ActorTwo Entity)
	{
		
		
		//base.Execute (Entity);	
	}

	public override void Exit (ActorTwo Entity)
	{
		//base.Exit (Entity);
	}

	public override bool OnMessage (ActorTwo Entity, Telegram telegram)
	{
		if (telegram.Msg == (int)message_type.msg_oneMessage) {
			
			
			Debug.Log(Entity.GetType()+ " receive " +EntityManager.Instance().GetEntityFromID(telegram.Sender) +" message ");
			Entity.GetFSM ().ChangeState (ActorTwo_StateTwo.Instance ());
			Debug.Log(Entity.GetType()+" change State to ActorTwo_StateTwo");
			return true;
		}
		
		
		
		return false;
	}
}

public class ActorTwo_StateOne : State<ActorTwo>
{
	private static ActorTwo_StateOne instance;
	public static ActorTwo_StateOne Instance ()
	{
		if (instance == null)
			instance = new ActorTwo_StateOne ();
		
		return instance;
	}

	public override void Enter (ActorTwo Entity)
	{
		//base.Enter (Entity);
		
	}

	public override void Execute (ActorTwo Entity)
	{
		//base.Execute (Entity);
		
	}

	public override void Exit (ActorTwo Entity)
	{
		//base.Exit (Entity);
	}

	public override bool OnMessage (ActorTwo Entity, Telegram telegram)
	{
		return false;
	}
}


public class ActorTwo_StateTwo : State<ActorTwo>
{
	private static ActorTwo_StateTwo instance;
	public static ActorTwo_StateTwo Instance ()
	{
		if (instance == null)
			instance = new ActorTwo_StateTwo ();
		
		return instance;
	}

	public override void Enter (ActorTwo Entity)
	{
		
		// delay
		// sender
		// receiver
		//message
		MessageDispatcher.Instance ().DispatchMessage(
				1f, 
				Entity.ID (), 
				(int)EntityID.m_ActorOne, 
				(int)message_type.msg_twoMessage, 
				Entity);
		
		Debug.Log(Entity.GetType()+
			" Send Message to: "
			+EntityManager.Instance().GetEntityFromID((int)EntityID.m_ActorOne));
		//
		//base.Enter (Entity);		
	}

	public override void Execute (ActorTwo pMiner)
	{
		//base.Execute (Entity);
		
		
	}

	public override void Exit (ActorTwo Entity)
	{
		//base.Exit (Entity);
	}

	public override bool OnMessage (ActorTwo Entity, Telegram telegram)
	{
		
		return false;
	}
}
