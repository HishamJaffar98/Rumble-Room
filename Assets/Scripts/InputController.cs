using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [Header("State Machines")]
    [SerializeField] MobilityStateMachine characterMobilitySM;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnMovement(InputAction.CallbackContext value)
	{
        if (value.phase==InputActionPhase.Canceled)
		{
            characterMobilitySM.ChangeState(characterMobilitySM.characterIdleState);
            Debug.Log("Stopped providing WASD input");
        }
	}
}
