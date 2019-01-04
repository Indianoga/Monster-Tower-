using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		CloseApp();
	}

	public void GoMenu()
	{
		LoadingScreenManager.LoadScene(0);
	}
	public void GoGame()
	{
		LoadingScreenManager.LoadScene(1);
	}
	public void GoStore()
	{
		LoadingScreenManager.LoadScene(2);
	}
	public void GoCredits()
	{
		LoadingScreenManager.LoadScene(3);
	}
	public void CloseGame()
	{
		Application.Quit();
	}

	void CloseApp()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
