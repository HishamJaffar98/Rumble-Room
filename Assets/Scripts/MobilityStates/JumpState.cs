using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : RunState
{
	float characterJumpPower;
	float startingYPos;
	bool isJumping = false;
	float gravityScaleModifier;
	Vector3 originalGravity;

	public JumpState(MobilityStateMachine i_MobilitySM, Rigidbody i_rigidbody, Transform i_transform,
					Animator i_animator, float i_runSpeed, float i_smoothFactor, float i_jumpPower, float i_gravityScaleModifier):base(i_MobilitySM, i_rigidbody, i_transform, i_animator, i_runSpeed, i_smoothFactor)
	{
		characterJumpPower = i_jumpPower;
		gravityScaleModifier = i_gravityScaleModifier;
	}

	public override void StateEnter()
	{
		originalGravity = Physics.gravity;
		startingYPos = characterTransform.position.y;
		characterRigidbody.AddForce(Vector2.up * characterJumpPower, ForceMode.Impulse);
		characterAnimator.SetTrigger("TransitionToJump");
	}

	public override void StateExit()
	{
		isJumping = false;
		Physics.gravity = originalGravity;
		Debug.Log("JumpStateExited");
	}

	public override void StateFixedTick()
	{
		if (characterTransform.position.y != startingYPos)
		{
			isJumping = true;
			AlterGravity();
			base.StateFixedTick();
		}

		if (characterTransform.position.y <= startingYPos && isJumping)
		{
			if(characterRigidbody.velocity.x==0)
			{
				Debug.Log(characterRigidbody.velocity.x);
				characterMobilitySM.ChangeState(characterMobilitySM.characterIdleState);
			}
			else
			{
				Debug.Log(characterRigidbody.velocity.x);
				characterMobilitySM.ChangeState(characterMobilitySM.characterRunState);
			}
		}
	}

	private void AlterGravity()
	{
		if (characterRigidbody.velocity.y <= 1)
		{
			if (Physics.gravity.magnitude > originalGravity.magnitude)
			{
				return;
			}
			Physics.gravity = originalGravity * gravityScaleModifier;
		}
	}

	public override void StateTick()
	{
		
	}

}
