using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameScreenUIManager : MonoBehaviour
{
    [SerializeField] Animator UIAnimator;
    public static event Action OnGameStart;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UIAnimator.GetCurrentAnimatorStateInfo(0).IsName("QuitGame") && UIAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Application.Quit();
        }
    }

    public void QuitGame()
	{
        SFXManager.instance.PlayButtonPressedSound();
        UIAnimator.SetTrigger("Quit");
	}

    public void StartGame()
	{
        OnGameStart?.Invoke();
        SFXManager.instance.PlayButtonPressedSound();
        gameObject.SetActive(false);
    }
}
