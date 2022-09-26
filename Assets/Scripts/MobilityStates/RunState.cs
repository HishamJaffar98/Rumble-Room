using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IState
{
	Rigidbody characterRigidbody;
	MobilityStateMachine characterMobilitySM;
	Animator characterAnimator;
	Transform characterTransform;
	float characterRunSpeed;
	float characterSmoothFactor;

	Vector2 direction;
	Vector2 smoothedOutDirection;
	public RunState(MobilityStateMachine i_MobilitySM, Rigidbody i_rigidbody, Transform i_transform, Animator i_animator, float i_runSpeed, float i_smoothFactor)
	{
		characterMobilitySM = i_MobilitySM;
		characterRigidbody = i_rigidbody;
		characterRunSpeed = i_runSpeed;
		characterAnimator = i_animator;
		characterTransform = i_transform;
		characterSmoothFactor = i_smoothFactor;
	}

	public void StateEnter()
	{
		Debug.Log("Run state entered");
		characterAnimator.SetTrigger("TransitionToRun");
		direction = characterMobilitySM.RawMovementInput;
	}

	public void StateTick()
	{

	}

	public void StateFixedTick()
	{
		SmoothDirectionValue();
		UpdateMovement();
	}

	private void SmoothDirectionValue()
	{
		direction = characterMobilitySM.RawMovementInput;
		smoothedOutDirection = Vector2.Lerp(smoothedOutDirection, direction, characterSmoothFactor * Time.deltaTime);
	}

	private void UpdateMovement()
	{
		Vector3 newPosition = new Vector3(characterTransform.position.x  + (smoothedOutDirection.x *characterRunSpeed * Time.deltaTime), characterTransform.position.y, 0f);
		characterTransform.position = newPosition;
		Debug.Log(smoothedOutDirection.x);
		if(Mathf.Abs(smoothedOutDirection.x) <0.02f)
		{
			characterMobilitySM.ChangeState(characterMobilitySM.characterIdleState);
		}
	}
	
	public void StateExit()
	{
		Debug.Log("Run state exited");
	}
}
