﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	[SerializeField]
	GameObject playBtn;
	[SerializeField]
	GameObject pauseBtn;
	[SerializeField]
	GameObject ContBtn;
	[SerializeField]
	GameObject gameManager;
	CreatEnemy creatEnemy;
	[SerializeField]
	GameObject playerManager;
	Player player;

	// Use this for initialization
	void Start () 
	{
		pauseBtn.SetActive(false);
		ContBtn.SetActive(false);
		creatEnemy = gameManager.GetComponent<CreatEnemy>();
		player = playerManager.GetComponent<Player>();
		for (int i = 0; i < player.playerImagLife.Length; i++)
		{
			player.playerImagLife[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void StartGame()
	{
		playBtn.SetActive(false);
		pauseBtn.SetActive(true);
		creatEnemy.isGame = true;
		for (int i = 0; i < player.playerImagLife.Length; i++)
		{
			player.playerImagLife[i].SetActive(true);
		}
		
	}

	public void PauseMenu(bool isPause)
	{

		if (!isPause)
		{
			Time.timeScale = 0;
			creatEnemy.isGame = false;
			pauseBtn.SetActive(false);
			ContBtn.SetActive(true);
		}
		else
		{
			Time.timeScale = 1;
			creatEnemy.isGame = true;
			pauseBtn.SetActive(true);
			ContBtn.SetActive(false);
		}
		

	}
}
