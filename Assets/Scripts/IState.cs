using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
	void StateEnter();
	void StateTick();
	void StateFixedTick();
	void StateExit();
}
