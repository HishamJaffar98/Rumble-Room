using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilityStateMachine : StateMachine
{

	#region States
	public IdleState characterIdleState;
	public RunState characterRunState;
	public JumpState characterJumpState;
	public DodgeState characterdodgeState;
	#endregion

	#region Components
	[Header("Shared State Components")]
	[SerializeField] Rigidbody characterRigidBody;
	[SerializeField] Transform characterTransform;
	[SerializeField] Animator characterAnimator;
	#endregion

	#region Variables
	private Vector2 rawMovementInput = new Vector2(0, 0);

	[Header("Run State Variables")]
	[SerializeField] float runSpeed;
	[SerializeField] float smoothFactor;
	[SerializeField] float stopFactor = 500f;

	[Header("Jump State Variables")]
	[SerializeField] float jumpPower;
	[SerializeField] float gravityScaleModifier;

	[Header("Dodge State Variables")]
	[SerializeField] LayerMask dodgeLayer;
	[SerializeField] float dodgeForce;

	#endregion

	public Vector2 RawMovementInput
	{
		get
		{
			return rawMovementInput;
		}
		set
		{
			rawMovementInput = value;
		}
	}

	public float StopFactor
	{
		get
		{
			return stopFactor;
		}
	}

	private void Awake()
	{
		characterIdleState = new IdleState(characterAnimator);
		characterRunState = new RunState(this, characterRigidBody, characterTransform, characterAnimator, runSpeed, smoothFactor);
		characterJumpState = new JumpState(this, characterRigidBody, characterTransform, characterAnimator, runSpeed, smoothFactor, jumpPower, gravityScaleModifier);
		characterdodgeState = new DodgeState(this, characterRigidBody, characterTransform, characterAnimator, runSpeed, smoothFactor, dodgeLayer, gravityScaleModifier, dodgeForce);
	}

	private void Start()
    {
		ChangeState(characterIdleState);
    }

	protected override void Update()
    {
        base.Update();
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();
	}

	public void SetLayer(LayerMask newLayer)
	{
		//gameObject.layer = newLayer;
	}

	public LayerMask GetLayer( )
	{
		return gameObject.layer;
	}
}
