using System.Collections;
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
		RandomSound();
		Invoke ("Delete", 2.0f); 
		
	}

	public void RightPunch()
	{
		
		GetComponent <Rigidbody> ().velocity = new Vector2 (-10, 0);
		GetComponent <Rigidbody> ().isKinematic = false;
		GetComponent <Rigidbody> ().AddTorque(new Vector3 (0,0,1) * 100 * 100);
		RandomSound();
		Invoke ("Delete", 2.0f);
	}

	void RandomSound()
	{
		int soundIndex = Random.Range(0, 15);
		if (soundIndex < 5)
		{
			SoundManager.instance.Play("Player",SoundManager.instance.clipList.boneBreak,0.1f);
		}
		else if(soundIndex > 5 && soundIndex < 10)
		{
			SoundManager.instance.Play("Player",SoundManager.instance.clipList.boneBreak1,0.1f);
		}
		else
		{
			SoundManager.instance.Play("Player",SoundManager.instance.clipList.boneBreak2,0.1f);	
		}
		
	}
	
	void Delete()
	{
		Destroy(gameObject);
	}
}
