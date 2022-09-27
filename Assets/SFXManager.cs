using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] AudioSource audioSource;
    static public SFXManager instance;

	private void Awake()
	{
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

	}
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonPressedSound()
	{
        audioSource.PlayOneShot(audioClips[0]);
	}

    public void PlayButtonHoveredSound()
    {
        audioSource.PlayOneShot(audioClips[1]);
    }
}
