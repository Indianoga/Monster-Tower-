using UnityEngine.Advertisements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsComponent : MonoBehaviour {

	public static AdsComponent instance;
	// Use this for initialization
	void Start () {
		
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

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
			case ShowResult.Finished:
			Debug.Log("The ad was successfully shown.");
			//
			// YOUR CODE TO REWARD THE GAMER
			// Give coins etc.
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
            


