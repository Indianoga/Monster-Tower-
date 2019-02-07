using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour 
{

	[SerializeField]
	Text gold;
	[SerializeField]
	Text [] itensPrice;
	int currentGold;
	int shields;
	int shieldsBought;
	int extraLifes;
	int extraLifesBought;
	int powerDestruction;
	int powerBought;
	int comboLife;

	[SerializeField]
	public ItensControls[] itensControls;

	// Use this for initialization
	void Start () 
	{
		
		currentGold = PlayerPrefs.GetInt("gold");
		//currentGold = 100;
		shields = PlayerPrefs.GetInt("shields");
		shieldsBought = PlayerPrefs.GetInt("shieldsBought");
		extraLifes = PlayerPrefs.GetInt("extraLife");
		extraLifesBought = PlayerPrefs.GetInt("extraLifeBought");
		powerDestruction = PlayerPrefs.GetInt("powerDestruction");
		powerBought = PlayerPrefs.GetInt("powerBought");
		comboLife = PlayerPrefs.GetInt("comboLife");
		//System Control :
		//shields = 0;
		//shieldsBought = 0;
		//extraLifes = 0;
		//extraLifesBought = 0;
		//powerDestruction = 0;
		//powerBought = 0;
		//comboLife = 0; 
		
		
	}

	
	// Update is called once per frame
	void Update () 
	{
		
		gold.text = currentGold.ToString();
		ItensBtnsCheck();
		ItensPriceCheck();
		ItensTextCheck();
		Saves();
		
		
	}

	void ItensPriceCheck()
	{
		if(shieldsBought >= 1)
		{
			itensControls[0].price = 500;
		}
		if(powerBought >= 1)
		{
			itensControls[1].price = 500;
		}
		if(extraLifesBought == 1)
		{
			itensControls[2].price = 15000;
		}
		if(extraLifesBought == 2)
		{
			itensControls[2].price = 30000;
		}
		
	}
	void ItensTextCheck()
	{
		itensPrice[0].text = string.Format("$ {0} ", itensControls[0].price);
		itensPrice[1].text = string.Format("$ {0} ", itensControls[1].price);
		itensPrice[2].text = string.Format("$ {0} ", itensControls[2].price);
		itensPrice[3].text = string.Format("$ {0} ", itensControls[3].price);
	}
	void Saves()
	{
		PlayerPrefs.SetInt("gold", currentGold);
		PlayerPrefs.SetInt("shields",shields);
		PlayerPrefs.SetInt("shieldsBought",shieldsBought);
		PlayerPrefs.SetInt("extraLife",extraLifes);
		PlayerPrefs.SetInt("extraLifeBought", extraLifesBought);
		PlayerPrefs.SetInt("powerDestruction",powerDestruction);
		PlayerPrefs.SetInt("powerBought",powerBought);
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
				shieldsBought++;
				

			}
		
		}

		if (item == "PowerDestroy")
		{
			if(currentGold >= itensControls[1].price)
			{
				
				currentGold -= itensControls[1].price;
				powerDestruction++;
				powerBought++;
				
			}
		}
		if (item == "ExtraLife")
		{
			if(currentGold >= itensControls[2].price)
			{
				
				currentGold -= itensControls[2].price;
				extraLifes++;
				extraLifesBought++;
				
		
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
