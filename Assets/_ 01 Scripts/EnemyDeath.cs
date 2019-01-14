﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

	public int enemyLife;
	
	private void Start() 
	{
		
	}
	void Update() 
	{
		
	}
	public void LeftPunch()
	{
		GetComponent <Rigidbody> ().velocity = new Vector2 (10, 0);
		GetComponent <Rigidbody> ().isKinematic = false;
		GetComponent <Rigidbody> ().AddTorque(new Vector3 (0,0,-1) * 100 * 100);
		Invoke ("Delete", 2.0f); 
	}

	public void RightPunch()
	{
		
		GetComponent <Rigidbody> ().velocity = new Vector2 (-10, 0);
		GetComponent <Rigidbody> ().isKinematic = false;
		GetComponent <Rigidbody> ().AddTorque(new Vector3 (0,0,1) * 100 * 100);
		Invoke ("Delete", 2.0f);
	}
	
	void Delete()
	{
		Destroy(gameObject);
	}
}
