using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBallControl : MonoBehaviour 
{
	public string id;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(id == "spike")
		{
			StartCoroutine("SpikeTime");
		}
	
	}
	void Movement ()
	{
		if (transform.position.y >= -5f )
		{
			Destroy(gameObject);
		}
	}

	IEnumerator SpikeTime()
	{
		yield return new WaitForSecondsRealtime(0.5f);
		Destroy(gameObject);
	}
}
