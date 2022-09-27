using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : RunState
{
	LayerMask dodgeLayer;
	LayerMask originalLayer;
	Vector3 originalGravity;
	float gravityModifier;
	float dodgeForce;
	public DodgeState(MobilityStateMachine i_MobilitySM, Rigidbody i_rigidbody, Transform i_transform, Animator i_animator, float i_runSpeed, float i_smoothFactor, LayerMask i_Layer, float i_gravityModifier,float i_dodgeForce)
		:base(i_MobilitySM, i_rigidbody, i_transform, i_animator, i_runSpeed, i_smoothFactor)
	{
		dodgeLayer = i_Layer;
		gravityModifier = i_gravityModifier;
		dodgeForce = i_dodgeForce;
	}

	public override void StateEnter()
	{
		originalGravity = Physics.gravity;
		PushDodgeIfInIdle();
		GetAndSetLayersForDodging();
	}

	private void GetAndSetLayersForDodging()
	{
		originalLayer = characterMobilitySM.GetLayer();
		characterMobilitySM.SetLayer(dodgeLayer);
	}

	private void PushDodgeIfInIdle()
	{
		if ((characterRigidbody.velocity.magnitude) <= 0.1f)
		{
			Debug.Log(characterTransform.forward.x);
			if (characterTransform.forward.x > 0)
			{
				Debug.Log(characterTransform.forward.x);
				characterRigidbody.AddForce(new Vector3(1,0.7f,0) * dodgeForce, ForceMode.Impulse);
			}
			else if (characterTransform.forward.x < 0)
			{
				characterRigidbody.AddForce(new Vector3(-1, 0.7f, 0) * dodgeForce, ForceMode.Impulse);
			}
			characterAnimator.SetTrigger("TransitionToDodge");
		}
		
	}

	public override void StateFixedTick()
	{

		base.StateFixedTick();
		AlterGravity();
		//throw new System.NotImplementedException();
	}

	public override void StateTick()
	{
		Debug.Log("Tick: " + characterTransform.forward.x);
		if (characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Dodge") && characterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
		{
			if((characterRigidbody.velocity.magnitude) <= 0.1f)
			{
				characterMobilitySM.ChangeState(characterMobilitySM.characterIdleState);
			}
			else if(characterRigidbody.velocity.magnitude >= 0.1f)
			{
				characterMobilitySM.ChangeState(characterMobilitySM.characterIdleState);
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
			Physics.gravity = originalGravity * gravityModifier;
		}
	}

	public override void StateExit()
	{
		characterMobilitySM.SetLayer(originalLayer);
		characterAnimator.ResetTrigger("TransitionToDodge");
	}
}
