using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
   [SerializeField] CinemachineVirtualCamera[] virtualCameras;
	int VC1priority;
	int VC2priority;

	private void OnEnable()
	{
		GameScreenUIManager.OnGameStart += SwitchCameraPriotities;
	}

	void Start()
    {
		VC1priority = virtualCameras[0].Priority;
		VC2priority = virtualCameras[1].Priority;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnDisable()
	{
		GameScreenUIManager.OnGameStart -= SwitchCameraPriotities;
	}

	private void SwitchCameraPriotities()
	{
		virtualCameras[0].Priority = VC2priority;
		virtualCameras[1].Priority = VC1priority;
	}
}
