using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{
	[SerializeField]
	Animator playerAnin;

	[SerializeField]
	public PlayerLifeManagerControl[] playerLifeManagerControls;

	[SerializeField]
	GameObject playerPrefab;

	[SerializeField]
	public int playerLife;
	
	[SerializeField]
	GameObject gameManager;

	CreatEnemy creatEnemy;
	float playerScale;

	[HideInInspector]
	public int shieldsPlayer;
	[HideInInspector]
	public int powerDestructionPlayer;
	[HideInInspector]
	public int extraLifePlayer;
	[HideInInspector]
	public int comboLifePlayer;

	

	// Use this for initialization
	void Start () 
	{
		playerScale = transform.localScale.x;
		playerAnin = GetComponentInChildren<Animator>();
		creatEnemy = gameManager.GetComponent<CreatEnemy>(); 
		ItensLoading();
		ExtraLifeControl ();
		ShieldControl();
	}

	void ItensLoading()
	{
		shieldsPlayer = PlayerPrefs.GetInt("shields");
		powerDestructionPlayer = PlayerPrefs.GetInt("powerDestruction");
		extraLifePlayer = PlayerPrefs.GetInt("extraLife");
		comboLifePlayer = PlayerPrefs.GetInt("comboLife");
	}
	
	// Update is called once per frame
	void Update ()
	{
		SaveItens();
		Debug.Log("Shields: " + shieldsPlayer);
	}
	void SaveItens()
	{
		PlayerPrefs.SetInt("shields", shieldsPlayer);
		PlayerPrefs.SetInt("powerDestruction",powerDestructionPlayer);

	}
	public void ExtraLifeControl ()
	{
		
		if (extraLifePlayer == 0)
			{
				playerLife = 1;
				for (int i = 0; i < playerLifeManagerControls.Length; i++)
				{
					if (playerLife == i)
					{
						if (i == 1)
						{
							playerLifeManagerControls[0].playerImageOn.SetActive(true);
							playerLifeManagerControls[0].playerImageOff.SetActive(true);
						}
						else
						{
							playerLifeManagerControls[i].playerImageOn.SetActive(false);
							playerLifeManagerControls[i].playerImageOff.SetActive(false);
						}
					}
				
				}
			}
		if (extraLifePlayer == 1)
		{
			playerLife = 2;
				for (int i = 0; i < playerLifeManagerControls.Length; i++)
				{
					if (playerLife == i)
					{
						if (i == 2)
						{
							playerLifeManagerControls[0].playerImageOn.SetActive(true);
							playerLifeManagerControls[0].playerImageOff.SetActive(true);
							playerLifeManagerControls[1].playerImageOn.SetActive(true);
							playerLifeManagerControls[1].playerImageOff.SetActive(true);
						}
						else
						{
							playerLifeManagerControls[i].playerImageOn.SetActive(false);
							playerLifeManagerControls[i].playerImageOff.SetActive(false);
						}
					}
				
				}
		}
		if (extraLifePlayer == 2)
		{
			playerLife = 3;
				for (int i = 0; i < playerLifeManagerControls.Length; i++)
				{
					if (playerLife == i)
					{
						if (i == 3)
						{
							playerLifeManagerControls[0].playerImageOn.SetActive(true);
							playerLifeManagerControls[0].playerImageOff.SetActive(true);
							playerLifeManagerControls[1].playerImageOn.SetActive(true);
							playerLifeManagerControls[1].playerImageOff.SetActive(true);
							playerLifeManagerControls[2].playerImageOn.SetActive(true);
							playerLifeManagerControls[2].playerImageOff.SetActive(true);
						}
						else
						{
							playerLifeManagerControls[i].playerImageOn.SetActive(false);
							playerLifeManagerControls[i].playerImageOff.SetActive(false);
						}
					}
				
				}
		}
		if (extraLifePlayer == 3)
		{
				playerLife = 4;
				for (int i = 0; i < playerLifeManagerControls.Length; i++)
				{
					playerLifeManagerControls[i].playerImageOn.SetActive(true);
					playerLifeManagerControls[i].playerImageOff.SetActive(true);
				}
		}
	}

	void ShieldControl()
	{
		if (shieldsPlayer > 0)
		{
			creatEnemy.shieldOff = false;
		}
		else 
		{
			creatEnemy.shieldOff = true;
		}
		Debug.Log(creatEnemy.shieldOff);
		
	}

	public void Right()
	{
		playerPrefab.transform.position = new Vector3(0.99f, playerPrefab.transform.position.y, 0);
		playerPrefab.transform.localScale = new Vector3 (-playerScale, 1,1);
		playerAnin.SetTrigger("punch");
		SoundManager.instance.Play("Player",SoundManager.instance.clipList.punchMaleEffect,0.1f);
	}
	public void Left()
	{
		playerPrefab.transform.position = new Vector3(-1.01f, playerPrefab.transform.position.y, 0);
		playerPrefab.transform.localScale = new Vector3 (playerScale, 1,1);
		playerAnin.SetTrigger("punch");
		SoundManager.instance.Play("Player",SoundManager.instance.clipList.punchMaleEffect,0.1f);
	}

	private void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("fireBall"))
		{
			creatEnemy.DamageControl();			
		}
	}
}

[System.Serializable]
public class PlayerLifeManagerControl
{
	public GameObject  playerImageOn;
	public GameObject  playerImageOff;
}

