using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
	private Animator characterAnimator;

	public IdleState(Animator i_characterAnimator)
	{
		characterAnimator = i_characterAnimator;
	}

	public void StateEnter()
	{
		Debug.Log("IdleStarted");
		characterAnimator.SetTrigger("TransitionToAttackIdle");
	}

	public void StateFixedTick()
	{
		//throw new System.NotImplementedException();
	}

	public void StateTick()
	{
		//throw new System.NotImplementedException();
	}

	public void StateExit()
	{
		characterAnimator.ResetTrigger("TransitionToAttackIdle");
		Debug.Log("IdleExit");
	}
}
