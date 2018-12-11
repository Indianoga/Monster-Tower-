using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatEnemy : MonoBehaviour {

	[SerializeField]
	GameObject [] enemyPrefab;

	List <GameObject> enemyList;

	// Use this for initialization
	void Start () 
	{
		enemyList = new List <GameObject>();
		InstatiateEnemy();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Punch();
			enemyList.RemoveAt(0);
			repositionEnemy();
		}
			
	}

	void Punch()
	{
		enemyList[0].SendMessage("Delete");
	}

	GameObject RandomEnemy (Vector2 posicao)
	{
	
		GameObject newEnemy;

		if (Random.value > 0.5f || enemyList.Count <= 1 ) 
		{

			newEnemy = Instantiate (enemyPrefab[0]);

		}
		else 
			{
				if(Random.value > 0.5f)
				{
					newEnemy = Instantiate (enemyPrefab[1]);
				}
				else 
				{
					newEnemy = Instantiate (enemyPrefab[2]);
				}
			}

		newEnemy.transform.position = posicao;

		return newEnemy;

		}

	void InstatiateEnemy()
	{
		for (int i = 0; i <= 8; i++ )
		{

			GameObject enemyPrebs = RandomEnemy (new Vector2 (0,-3.53f + (i * 0.99f)));
			enemyList.Add (enemyPrebs);
			
		}
	}

	void repositionEnemy()
	{

		GameObject enemyPrebs = RandomEnemy (new Vector2 (0,-3.53f + (8 * 0.99f)));
		enemyList.Add (enemyPrebs);

		for (int i = 0; i <= 7; i++) 
		{
			enemyList [i].transform.position = new Vector2 (enemyList[i].transform.position.x, enemyList[i].transform.position.y - 0.99f);
		}
	}

	void Delete()
	{
		Destroy(gameObject);
	}
}
