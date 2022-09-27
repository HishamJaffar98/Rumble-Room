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
			if (characterTransform.forward.x > 0)
			{
				characterRigidbody.AddForce(Vector2.right * dodgeForce, ForceMode.Impulse);
			}
			else if (characterTransform.forward.x < 0)
			{
				characterRigidbody.AddForce(Vector2.left * dodgeForce, ForceMode.Impulse);
			}
			characterAnimator.SetTrigger("TransitionToDodge");
		}
		
	}

	public override void StateFixedTick()
	{
		base.StateFixedTick();
	}

	public override void StateTick()
	{
		if (characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Dodge") && characterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
		{
			if((characterRigidbody.velocity.magnitude) <= 0.1f)
			{
				characterMobilitySM.ChangeState(characterMobilitySM.characterIdleState);
			}
			else if(characterRigidbody.velocity.magnitude > 0.1f)
			{
				characterMobilitySM.ChangeState(characterMobilitySM.characterRunState);
			}
		}
	}

	public override void StateExit()
	{
		Physics.gravity = originalGravity;
		characterMobilitySM.SetLayer(originalLayer);
		characterAnimator.ResetTrigger("TransitionToDodge");
	}
}
