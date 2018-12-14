using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	[SerializeField]
	GameObject playerPrefab;

	float playerScale;

	// Use this for initialization
	void Start () 
	{
		playerScale = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Right()
	{
		
		playerPrefab.transform.position = new Vector3(0.99f, playerPrefab.transform.position.y, 0);
		playerPrefab.transform.localScale = new Vector3 (-playerScale, 1,1);
	}
	public void Left()
	{
		
		playerPrefab.transform.position = new Vector3(-1.01f, playerPrefab.transform.position.y, 0);
		playerPrefab.transform.localScale = new Vector3 (playerScale, 1,1);
	}

	
}
