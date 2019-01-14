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
	}

	void ItensLoading()
	{
		shieldsPlayer = PlayerPrefs.GetInt("shields");
		extraLifePlayer = PlayerPrefs.GetInt("extraLife");
		powerDestructionPlayer = PlayerPrefs.GetInt("powerDestruction");
		comboLifePlayer = PlayerPrefs.GetInt("comboLife");
	}
	
	// Update is called once per frame
	void Update ()
	{
		ExtraLifeControl ();
	}

	public void ExtraLifeControl ()
	{
		
		if (extraLifePlayer == 0)
		{
			playerLife = 1;
		}
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
			creatEnemy.StartCoroutine("GameOver");			
		}
	}
}

[System.Serializable]
public class PlayerLifeManagerControl
{
	public GameObject  playerImageOn;
	public GameObject  playerImageOff;
}

