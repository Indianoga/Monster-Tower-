using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour 
{
	[SerializeField]
	Text gold;
	int currentGold;
	[SerializeField]
	public ItensControls[] itensControls;

	// Use this for initialization
	void Start () 
	{
		currentGold = PlayerPrefs.GetInt("gold");
	}
	
	// Update is called once per frame
	void Update () 
	{
		gold.text = currentGold.ToString();
	}

	public void Buy(string item)
	{
		if (item == "Shield")
		{
			if(currentGold > itensControls[0].price)
			{
				Debug.Log("I can Buy");
			}
			else
			{
				Debug.Log("I need more money");
			}
		}
		
	}
}
