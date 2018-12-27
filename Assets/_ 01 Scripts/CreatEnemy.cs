using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreatEnemy : MonoBehaviour {

	
	
	bool playerSide;

	public bool isGame = false;

	[SerializeField]
	GameObject gameManager;
	Player player;
	[SerializeField]
	EnemyLifePrefabControl [] enemyLifePrefabControl;
	
	GameObject newEnemy;
	int enemyLifeManager;
	int startPosition;

	List <GameObject> enemyList;

	public int enemyCont;

	// Use this for initialization
	void Start () 
	{
		
		enemyList = new List <GameObject>();
		player = gameManager.GetComponent<Player>();
		InstantiateEnemy();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isGame)
		{
			
			if (Input.GetButtonDown("Fire1"))
			{
				if (Input.mousePosition.x > Screen.width/2)
				{
					SendMessage("Right");
					playerSide = true;
					if (enemyList[0].GetComponent<EnemyDeath>().enemyLife <= 0)
					{
						enemyList[0].SendMessage("RightPunch");
						enemyList.RemoveAt(0);
						repositionEnemy();
				}
				else
				{
					enemyList[0].GetComponent<EnemyDeath>().enemyLife--;
				}
			}
			
			else
			{
				SendMessage("Left");
				playerSide = false;
				if (enemyList[0].GetComponent<EnemyDeath>().enemyLife <= 0)
				{
					enemyList[0].SendMessage("LeftPunch");
					enemyList.RemoveAt(0);
					repositionEnemy();
				}
				else
				{
					enemyList[0].GetComponent<EnemyDeath>().enemyLife--;
				}
			}
			enemyCont++;
			DoDamage();
		}
		}
		
	}


	
	GameObject RandomEnemy (Vector2 posicao)
	{
		int index = Random.Range(0,enemyLifePrefabControl.Length);
		GameObject newEnemy = enemyLifePrefabControl[index].enemyPrefab;
		
		if (enemyList.Count <= 1)
		{
			newEnemy = Instantiate(enemyLifePrefabControl[0].enemyPrefab);
		}
		else
		{
			newEnemy = Instantiate (enemyLifePrefabControl[index].enemyPrefab);
		}
		
		newEnemy.transform.position = posicao;
		return newEnemy;

	}

	

	void InstantiateEnemy()
	{
		
		for (int i = 0; i <= 8; i++ )
		{

			GameObject enemyPrefabsInstantiats = RandomEnemy (new Vector2 (0.05f,-3.06f + (i * 0.99f)));
			enemyList.Add (enemyPrefabsInstantiats);
			 
		}
		
		
	}


	void repositionEnemy()
	{

		GameObject enemyPrefabsInstantiats = RandomEnemy (new Vector2 (0.05f,-3.06f + (8 * 0.99f)));
		enemyList.Add (enemyPrefabsInstantiats);

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
				player.playerLife--;
				if (player.playerLife <= 2)
				{
					player.playerImagLife[2].SetActive(false);
				}
				if (player.playerLife <= 1)
				{
					player.playerImagLife[1].SetActive(false);
				}
				if (player.playerLife <= 0)
				{
					player.playerImagLife[0].SetActive(false);
				}
				
				if (player.playerLife <= 0)
				{
					GameOver();
				}
			}
		}
	}
	void GameOver()
	{
		
		SceneManager.LoadScene("Game");
		
		
	}
}
