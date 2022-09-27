using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
	[SerializeField] GameObject[] worldEntities;
	private void OnEnable()
	{
		GameScreenUIManager.OnGameStart += ShowGameEntities;
	}
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	private void OnDisable()
	{
		GameScreenUIManager.OnGameStart -= ShowGameEntities;
	}
	
	private void ShowGameEntities()
	{
		foreach(GameObject entity in worldEntities)
		{
			entity.SetActive(true);
		}
	}
	
}
