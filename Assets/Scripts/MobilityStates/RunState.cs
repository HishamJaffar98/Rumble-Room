using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IState
{
	protected Rigidbody characterRigidbody;
	protected MobilityStateMachine characterMobilitySM;
	protected Animator characterAnimator;
	protected Transform characterTransform;
	float characterRunSpeed;
	float characterSmoothFactor;

	protected Vector2 direction;
	protected Vector2 smoothedOutDirection;
	public RunState(MobilityStateMachine i_MobilitySM, Rigidbody i_rigidbody, Transform i_transform, Animator i_animator, float i_runSpeed, float i_smoothFactor)
	{
		characterMobilitySM = i_MobilitySM;
		characterRigidbody = i_rigidbody;
		characterRunSpeed = i_runSpeed;
		characterAnimator = i_animator;
		characterTransform = i_transform;
		characterSmoothFactor = i_smoothFactor;
	}

	public virtual void StateEnter()
	{
		Debug.Log("Run state entered");
		characterAnimator.SetTrigger("TransitionToRun");
		direction = characterMobilitySM.RawMovementInput;

	}

	public virtual void StateTick()
	{

	}

	public virtual void StateFixedTick()
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
		Vector3 newPosition = new Vector3(characterTransform.position.x + (smoothedOutDirection.x * characterRunSpeed * Time.deltaTime), characterTransform.position.y, 0f);
		characterTransform.position = newPosition;
		RotateCharacter();
		if (Mathf.Abs(smoothedOutDirection.x) < 0.02f && characterMobilitySM.currentState == characterMobilitySM.characterRunState)
		{
			characterMobilitySM.ChangeState(characterMobilitySM.characterIdleState);
		}
	}

	private void RotateCharacter()
	{
		if ((Vector2)characterTransform.transform.forward != direction.normalized && direction.normalized != Vector2.zero)
		{
			characterTransform.transform.forward = direction.normalized;
		}
	}

	public virtual void StateExit()
	{
		characterAnimator.ResetTrigger("TransitionToRun");
		Debug.Log("Run state Exited");
	}
}
