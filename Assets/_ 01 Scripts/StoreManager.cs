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
		//currentGold = 30000;
		shields = PlayerPrefs.GetInt("shields");
		extraLifes = PlayerPrefs.GetInt("extraLife");
		powerDestruction = PlayerPrefs.GetInt("powerDestruction");
		comboLife = PlayerPrefs.GetInt("comboLife");
		//System Control :
		//shields = 0;
		//extraLifes = 0;
		//powerDestruction = 0;
		//comboLife = 0; 
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		gold.text = currentGold.ToString();
		ItensBtnsCheck();
		Saves();
		Debug.Log("Shields: " + shields + " PowerDestructions: " + powerDestruction + " ComboLifes: " + comboLife + " ExtraLifes: " + extraLifes);
		
	}
	void Saves()
	{
		PlayerPrefs.SetInt("gold", currentGold);
		PlayerPrefs.SetInt("shields",shields);
		PlayerPrefs.SetInt("extraLife",extraLifes);
		PlayerPrefs.SetInt("powerDestruction",powerDestruction);
		PlayerPrefs.SetInt("comboLife",comboLife);
	}

	public void Buy(string item)
	{
		if (item == "Shield")
		{
			if(currentGold >= itensControls[0].price)
			{
				
				currentGold -=  itensControls[0].price;
				shields++;
			}
		
		}

		if (item == "PowerDestroy")
		{
			if(currentGold >= itensControls[1].price)
			{
				
				currentGold -= itensControls[1].price;
				powerDestruction++;
			}
		}
		if (item == "ExtraLife")
		{
			if(currentGold >= itensControls[2].price)
			{
				
				currentGold -= itensControls[2].price;
				extraLifes++;
				
			}
		}

		if (item == "ComboLife")
		{
			if(currentGold >= itensControls[3].price)
			{
				
				currentGold -= itensControls[3].price;
				comboLife++;
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
