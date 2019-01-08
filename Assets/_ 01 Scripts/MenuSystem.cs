using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSystem : MonoBehaviour {

	[SerializeField]
	GameObject levelSystemPrefab;
	[SerializeField]
	GameObject quitMenuPrefab;

	[SerializeField]
	Transform LevelSelectedManager;
	[SerializeField]
	Transform[] targetsPosition;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void ChangLevel(bool side)
	{
		if (!side)
		{
			LevelSelectedManager.transform.position = Vector2.MoveTowards(LevelSelectedManager.transform.position,targetsPosition[0].position, 200000f * Time.deltaTime);
		}
		else
		{
			LevelSelectedManager.transform.position = Vector2.MoveTowards(LevelSelectedManager.transform.position,targetsPosition[1].position, 200000f * Time.deltaTime);

		}
	}
	public void OpenLevelSystem(bool open)
	{
		if(!open)
		{
			levelSystemPrefab.SetActive(true);
		}else
		{
			levelSystemPrefab.SetActive(false);
		}
	}

	public void OpenQuitMenu(bool open)
	{
		if(!open)
		{
			quitMenuPrefab.SetActive(true);
		}else
		{
			quitMenuPrefab.SetActive(false);
		}
	}

	
}
