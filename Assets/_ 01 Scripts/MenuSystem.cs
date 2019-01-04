using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSystem : MonoBehaviour {

	[SerializeField]
	GameObject levelSystemPrefab;
	[SerializeField]
	GameObject quitMenuPrefab;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
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
