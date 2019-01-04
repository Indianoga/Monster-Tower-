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
	public GameObject[] playerImagLife;

	[SerializeField]
	GameObject playerPrefab;

	[SerializeField]
	public int playerLife;
	float playerScale;

	// Use this for initialization
	void Start () 
	{
		playerScale = transform.localScale.x;
		playerAnin = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Right()
	{
		playerPrefab.transform.position = new Vector3(0.99f, playerPrefab.transform.position.y, 0);
		playerPrefab.transform.localScale = new Vector3 (-playerScale, 1,1);
		playerAnin.SetTrigger("punch");
		SoundManager.instance.Play("Player",SoundManager.instance.clipList.punchMaleEffect);
	}
	public void Left()
	{
		playerPrefab.transform.position = new Vector3(-1.01f, playerPrefab.transform.position.y, 0);
		playerPrefab.transform.localScale = new Vector3 (playerScale, 1,1);
		playerAnin.SetTrigger("punch");
		SoundManager.instance.Play("Player",SoundManager.instance.clipList.punchMaleEffect);
	}

	private void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("fireBall"))
		{
			SceneManager.LoadScene("Game");		}
	}

	
}
