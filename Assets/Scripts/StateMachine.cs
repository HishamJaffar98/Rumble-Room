using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
	public IState currentState;
	public IState previousState;
	private bool isTransitioning;

	private void ChangeStateRoutine(IState newState)
	{
		isTransitioning = true;

		if (currentState != null)
			currentState.StateExit();

		previousState = currentState;
		currentState = newState;

		if (currentState != null)
			currentState.StateEnter();

		isTransitioning = false;
	}

	public void ChangeState(IState newState)
	{
		if (currentState == newState || isTransitioning)
			return;
		ChangeStateRoutine(newState);
	}

	public void RevertState()
	{
		if (previousState == null)
			return;
		ChangeState(previousState);
	}

	protected virtual void Update()
	{
		if (currentState != null && !isTransitioning)
			currentState.StateTick();
	}

	protected virtual void FixedUpdate()
	{
		if (currentState != null && !isTransitioning)
			currentState.StateFixedTick();
	}


}
