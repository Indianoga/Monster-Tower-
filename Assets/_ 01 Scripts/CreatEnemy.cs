using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreatEnemy : MonoBehaviour {

	

	bool playerSide;
	[SerializeField]
	EnemyLifePrefabControl [] enemyLifePrefabControl;
	
	GameObject enemyPrebs;
	int startPosition;

	List <GameObject> enemyList;

	public int enemyCont;

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
			if (Input.mousePosition.x > Screen.width/2)
			{
				SendMessage("Right");
				enemyList[0].SendMessage("RightPunch");
				playerSide = true;
			}
			
			else
			{
				SendMessage("Left");
				enemyList[0].SendMessage("LeftPunch");
				playerSide = false;
				
			}
		
			enemyList.RemoveAt(0);
			enemyCont++;
			repositionEnemy();
			DoDamage();
			
		}
			
	}
	

	GameObject RandomEnemy (Vector2 posicao)
	{
		
		GameObject newEnemy;

		if (Random.value > 0.5f || enemyList.Count <= 1 ) 
		{

			newEnemy = Instantiate (enemyLifePrefabControl[0].enemyPrefab);

		}
		else 
			{
				if(Random.value > 0.5f)
				{
					newEnemy = Instantiate (enemyLifePrefabControl[1].enemyPrefab);
				}
				else 
				{
					newEnemy = Instantiate (enemyLifePrefabControl[2].enemyPrefab);
				}
			}

		newEnemy.transform.position = posicao;

		return newEnemy;

	}

	

	void InstatiateEnemy()
	{
		
		for (int i = 0; i <= 8; i++ )
		{

			GameObject enemyPrebs = RandomEnemy (new Vector2 (0.05f,-3.53f + (i * 0.99f)));
			enemyList.Add (enemyPrebs);
			 
		}
		
		
	}


	void repositionEnemy()
	{

		GameObject enemyPrebs = RandomEnemy (new Vector2 (0.05f,-3.53f + (8 * 0.99f)));
		enemyList.Add (enemyPrebs);

		for (int i = 0; i <= 7; i++) 
		{
			enemyList [i].transform.position = new Vector2 (enemyList[i].transform.position.x, enemyList[i].transform.position.y - 0.99f);
		}
	}
	
	void DoDamage()
	{
		if (enemyList[0].gameObject.CompareTag ("enemy") )
		{
			if ((enemyList[0].name == "MonsterEsq(Clone)" && !playerSide) || (enemyList[0].name == "MonsterDir(Clone)" && playerSide))
			{
				
				GameOver();
			}
		}
	}
	void Delete()
	{
		Destroy(gameObject);
	}

	void GameOver()
	{
		
		SceneManager.LoadScene("Game");
		
		
	}
}
