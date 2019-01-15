using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnaliticsSystem : MonoBehaviour {

	[SerializeField]
	Text[] analiticsTxt;

	float timePlayed;
	float bestTime;
	int brokenBones;
	int shieldsBuys;
	int currentShields;
	int powerDestructionBuy;
	
	void Start () 
	{
		timePlayed = PlayerPrefs.GetFloat("timePlayed");
		bestTime = PlayerPrefs.GetFloat("bestTimePlayed");
		brokenBones = PlayerPrefs.GetInt("enemyNumber");
		shieldsBuys = PlayerPrefs.GetInt("shieldsBought");
		powerDestructionBuy = PlayerPrefs.GetInt("powerBought");		
	}
	
	// Update is called once per frame
	void Update () 
	{
		TimePlayedSystem();
		BestTimePlayed();
		BoneBreaksCount();
		ShieldCountAndPower();
	
		
	}
	void TimePlayedSystem()
	{
		int seconds = (int)timePlayed;
		int minutes = seconds / 60;
		seconds = seconds % 60;
		analiticsTxt[0].text = string.Format("Time played: {0}:{1}", minutes.ToString("00"), seconds.ToString("00"));
	}
	void BestTimePlayed()
	{
		int seconds = (int)bestTime;
		int minutes = seconds / 60;
		seconds = seconds % 60;
		analiticsTxt[1].text = string.Format("Best Time: {0}:{1}", minutes.ToString("00"), seconds.ToString("00"));
	}

	void BoneBreaksCount()
	{
		int value = (int)brokenBones;
		analiticsTxt[2].text = string.Format("Broken Bones: {0} " ,value.ToString("00"));
	}
	void ShieldCountAndPower()
	{
		analiticsTxt[3].text = string.Format("Shields bought: {0}", shieldsBuys.ToString("00"));
		analiticsTxt[4].text = string.Format("Power Bought: {0}", powerDestructionBuy.ToString("00"));
	}
}
