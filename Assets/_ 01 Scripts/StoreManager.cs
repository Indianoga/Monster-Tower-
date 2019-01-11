using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour 
{
	[SerializeField]
	Text gold;
	int currentGold;
	int shields;
	int extraLifes;
	int powerDestruction;
	int comboLife;

	[SerializeField]
	public ItensControls[] itensControls;

	// Use this for initialization
	void Start () 
	{
		currentGold = PlayerPrefs.GetInt("gold");
		extraLifes = PlayerPrefs.GetInt("extraLife");
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		gold.text = currentGold.ToString();
		ItensBtnsCheck();
		PlayerPrefs.SetInt("gold", currentGold);
		PlayerPrefs.SetInt("extraLife",extraLifes);
		
	}

	public void Buy(string item)
	{
		if (item == "Shield")
		{
			if(currentGold >= itensControls[0].price)
			{
				Debug.Log("I can Buy");
				currentGold = currentGold - itensControls[0].price;
			}
			else
			{
				Debug.Log("I need more money");
			}
		}

		if (item == "PowerDestroy")
		{
			if(currentGold >= itensControls[1].price)
			{
				Debug.Log("I can Buy");
				currentGold = currentGold - itensControls[1].price;
			}
		}

		if (item == "ComboLife")
		{
			if(currentGold >= itensControls[2].price)
			{
				Debug.Log("I can Buy");
				currentGold = currentGold - itensControls[2].price;
				comboLife++;
			}
		}
	
		if (item == "ExtraLife")
		{
			if(currentGold >= itensControls[3].price && extraLifes < 3)
			{
				Debug.Log("I can Buy");
				currentGold = currentGold - itensControls[3].price;
				extraLifes++;
				Debug.Log(extraLifes);
			}
		}
		
	}

	void ItensBtnsCheck()
	{
		if (extraLifes >= 3)
		{
			itensControls[2].itenBtns.interactable = false;
		}
		if (comboLife >= 1)
		{
			itensControls[3].itenBtns.interactable = false;
		}
	}
}
