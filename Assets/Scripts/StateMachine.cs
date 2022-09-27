using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachine : MonoBehaviour
{
	public IState currentState;
	public IState previousState;
	private bool isTransitioning;

	public static event Action<IState,IState> OnStateChange;

	private void ChangeStateRoutine(IState newState)
	{
		isTransitioning = true;

		if (currentState != null)
			currentState.StateExit();

		previousState = currentState;
		currentState = newState;

		OnStateChange?.Invoke(previousState, currentState);
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
