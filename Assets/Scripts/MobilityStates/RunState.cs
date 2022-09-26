using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IState
{
	Rigidbody characterRigidbody;
	public RunState(Rigidbody i_rigidbody)
	{
		characterRigidbody = i_rigidbody;
	}

	public void StateEnter()
	{
		throw new System.NotImplementedException();
	}

	public void StateExit()
	{
		throw new System.NotImplementedException();
	}

	public void StateFixedTick()
	{
		throw new System.NotImplementedException();
	}

	public void StateTick()
	{
		throw new System.NotImplementedException();
	}
}
