using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBallControl : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void Movement ()
	{
		if (transform.position.y >= -5f )
		{
			Destroy(gameObject);
		}
	}
}
