using UnityEngine;
using System.Collections;

public class ActorOne_GloballState :State<ActorOne >
{
	private static ActorOne_GloballState instance;
	public static ActorOne_GloballState Instance ()
	{
		if (instance == null)
			instance = new ActorOne_GloballState ();
		
		return instance;
	}


	public override void Enter (ActorOne Entity)
	{
		//base.Enter (Entity);
	}

	public override void Execute (ActorOne Entity)
	{
		//base.Execute (Entity);	
	}

	public override void Exit (ActorOne Entity)
	{
		//base.Exit (Entity);
	}

	public override bool OnMessage (ActorOne Entity, Telegram telegram)
	{
		return false;
	}
}

public class ActorOne_StateOne : State<ActorOne>
{
	private static ActorOne_StateOne instance;
	public static ActorOne_StateOne Instance ()
	{
		if (instance == null)
			instance = new ActorOne_StateOne ();
		
		return instance;
	}
	
	public override void Enter (ActorOne Entity)
	{
		Debug.Log(Entity.GetType()+"::Enter ActorOne_StateOne ");
		Entity.oriV3 = Entity.transform.position;
		//base.Enter (Entity);
	}

	public override void Execute (ActorOne Entity)
	{
		Debug.Log(Entity.GetType()+"::Execute ActorOne_StateOne ");
		Debug.Log(Entity.GetType()+" ChangeState to ActorOne_StateTwo");
		Entity.GetFSM().ChangeState(ActorOne_StateTwo.Instance());
		//base.Execute (Entity);
	}

	public override void Exit (ActorOne Entity)
	{
		Debug.Log(Entity.GetType()+"::Exit ActorOne_StateOne ");
		//base.Exit (Entity);
	}

	public override bool OnMessage (ActorOne Entity, Telegram telegram)
	{
		return false;
	}
}


public class ActorOne_StateTwo : State<ActorOne>
{
	private static ActorOne_StateTwo instance;
	public static ActorOne_StateTwo Instance ()
	{
		if (instance == null)
			instance = new ActorOne_StateTwo ();
		
		return instance;
	}
	
	public override void Enter (ActorOne Entity)
	{
				MessageDispatcher.Instance().DispatchMessage(5f, // delay
                              Entity.ID(),        // sender
                              (int)EntityID.m_ActorTwo,            // receiver
                              (int)message_type.msg_oneMessage,    //message
								Entity);  //
		
		Debug.Log(Entity.GetType()+
			" Send Message to: "
			+EntityManager.Instance().GetEntityFromID((int)EntityID.m_ActorTwo));
		
		Debug.Log("Wait Five seconds ............................");
		//base.Enter (Entity);
	}

	public override void Execute (ActorOne Entity)
	{
		
		
		if(Entity.isBackToPosition == false)
		{
			
		 	Entity.transform.position = Vector3.Lerp(Entity.transform.position,Entity.TwoTransform.position,1f*Time.deltaTime);
		}
		else
		{
			Entity.transform.position = Vector3.Lerp(Entity.transform.position,Entity.oriV3,1f*Time.deltaTime);
		}
		//base.Execute (Entity);
	}

	public override void Exit (ActorOne Entity)
	{
		//base.Exit (Entity);
	}

	public override bool OnMessage (ActorOne Entity, Telegram telegram)
	{
		if(telegram.Msg == (int)message_type.msg_twoMessage)
		{
			Entity.isBackToPosition =true;
			Debug.Log(Entity.GetType()+ " receive " +EntityManager.Instance().GetEntityFromID(telegram.Sender) +" message ");
			return true;
		}
		
		return false;
	}
}