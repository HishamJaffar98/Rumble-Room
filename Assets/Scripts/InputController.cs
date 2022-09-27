using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

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
        Vector2 rawInput = value.ReadValue<Vector2>();
        characterMobilitySM.RawMovementInput = rawInput;
        if (value.phase == InputActionPhase.Performed)
		{
            if(characterMobilitySM.currentState!= characterMobilitySM.characterJumpState)
                characterMobilitySM.ChangeState(characterMobilitySM.characterRunState);
        }
    }

    public void OnJump(InputAction.CallbackContext value)
	{
        if(value.phase == InputActionPhase.Performed)
	    {
           characterMobilitySM.ChangeState(characterMobilitySM.characterJumpState);
        }
	}

    public void OnDodge(InputAction.CallbackContext value)
	{
        if (value.phase == InputActionPhase.Performed)
        {
            if (characterMobilitySM.currentState != characterMobilitySM.characterJumpState)
                characterMobilitySM.ChangeState(characterMobilitySM.characterdodgeState);
        }
    }        
}
