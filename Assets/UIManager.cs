using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentStateText;
    [SerializeField] TextMeshProUGUI prevStateText;
    [SerializeField] MobilityStateMachine mobsm;
	private void OnEnable()
	{
        StateMachine.OnStateChange += ChangeStateText;

    }

	private void OnDisable()
	{
        StateMachine.OnStateChange += ChangeStateText;

    }

    private void ChangeStateText(IState previousState, IState currentState)
	{
        ChangeStateTextValue(previousState,prevStateText, "PREVIOUS STATE: ");
        ChangeStateTextValue(currentState, currentStateText, "CURRENT STATE: ");
    }

    private void ChangeStateTextValue(IState stateToCheck, TextMeshProUGUI componentToFill,string InitalText)
	{
        if (stateToCheck == mobsm.characterIdleState)
        {
            componentToFill.text = InitalText + "IDLE";
        }
        else if (stateToCheck == mobsm.characterRunState)
        {
            componentToFill.text = InitalText + "RUN";
        }
        else if (stateToCheck == mobsm.characterJumpState)
        {
            componentToFill.text = InitalText + "JUMP";
        }
        else if (stateToCheck == mobsm.characterdodgeState)
        {
            componentToFill.text = InitalText + "DODGE";
        }
    }
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
