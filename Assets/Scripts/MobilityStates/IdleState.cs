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
		characterAnimator.SetTrigger("TransitionToAttackIdle");
		Debug.Log("IdleStarted");
	}

	public void StateExit()
	{
		throw new System.NotImplementedException();
	}

	public void StateFixedTick()
	{
		//throw new System.NotImplementedException();
	}

	public void StateTick()
	{
		//throw new System.NotImplementedException();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
