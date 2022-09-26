using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilityStateMachine : StateMachine
{
    public IdleState characterIdleState;
	public RunState characterRunState;

	[Header("R")]
	[SerializeField] Animator characterAnimator;
	[SerializeField] Rigidbody characterRigidBody;

	private void Awake()
	{
		characterIdleState = new IdleState(characterAnimator);
		characterRunState = new RunState(characterRigidBody);
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
}
