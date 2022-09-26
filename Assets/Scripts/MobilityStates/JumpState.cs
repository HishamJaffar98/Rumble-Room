using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IState
{
	MobilityStateMachine characterMobilitySM;
	Rigidbody characterRigidbody;
	Animator characterAnimator;
	float characterJumpPower;
	public JumpState(MobilityStateMachine i_MobilitySM, Rigidbody i_rigidbody, Animator i_animator, float i_jumpPower)
	{
		characterMobilitySM = i_MobilitySM;
		characterRigidbody = i_rigidbody;
		characterAnimator = i_animator;
		characterJumpPower = i_jumpPower;
	}

	public void StateEnter()
	{
		//characterAnimator.SetTrigger("TransitionToJump");
		characterRigidbody.AddForce(Vector2.up * characterJumpPower, ForceMode.Impulse);
	}

	public void StateExit()
	{
		//throw new System.NotImplementedException();
	}

	public void StateFixedTick()
	{
		//throw new System.NotImplementedException();
	}

	public void StateTick()
	{
		//throw new System.NotImplementedException();
	}

}
