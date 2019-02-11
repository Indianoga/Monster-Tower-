using UnityEngine.Advertisements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdsComponent : MonoBehaviour {

	public static AdsComponent instanceAds;

	StoreManager storeManager;
	[SerializeField]
	GameObject storePrefab;
	
	[HideInInspector]
	public static bool reward = true;
	


	// Use this for initialization

	private void Awake() 
	{
		storePrefab = GameObject.FindGameObjectWithTag("storeManager");
		storeManager = storePrefab.GetComponent<StoreManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{ 
		
  	  
	} 

	public void ShowAds()
	{
		Advertisement.Show();
	}
	public void ShowRewardedAd()
	{ 
		
	if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
				
		}
		
		
	}

	public void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
			case ShowResult.Finished:
			Debug.Log("The ad was successfully shown.");
			storeManager.currentGold += 1000;
			break;
			case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
			case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}

}
            


