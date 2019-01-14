using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreatEnemy : MonoBehaviour 
{	
	bool playerSide;
	[HideInInspector]
	public bool isGame = false;
	public Text  gold;
	[SerializeField]
	GameObject playerManager;
	Player player;
	[SerializeField]
	EnemyLifePrefabControl [] enemyLifePrefabControl;
	[SerializeField]
	Transform[] FireBallSpawner;
	[SerializeField]
	GameObject fireBall;

	[Header ("Game Over System")]
	[SerializeField]
	GameObject gameOverPrefab;
	[SerializeField]
	Animator gameOverPanel;

	float time;
	
	int enemyLifeManager;
	int startPosition;

	public bool shieldOff;

	List <GameObject> enemyList;
	
	AdsComponent ads;
	
	[HideInInspector]
	public int getGold;
	[HideInInspector]
	public int playerComboLifeSteal;




	// Use this for initialization
	void Start () 
	{
		
		enemyList = new List <GameObject>();
		ads = GetComponent<AdsComponent>();
		player = playerManager.GetComponent<Player>();
		getGold = PlayerPrefs.GetInt("gold");
		InstantiateEnemy();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		PlayerPrefs.GetInt("gold",getGold);
		//pcGame();
		androidGame();
	}

	
	void pcGame()
	{
		if (isGame)
		{
			
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				player.Right();
				playerSide = true;
				if (enemyList[0].GetComponent<EnemyDeath>().enemyLife <= 0)
					{
						enemyList[0].GetComponent<EnemyDeath>().RightPunch();
						enemyList.RemoveAt(0);
						repositionEnemy();
					}
					else
					{
						enemyList[0].GetComponent<EnemyDeath>().enemyLife--;
					}
					PlayerDamaged();
			}
			
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				player.Left();
				playerSide = false;
				if (enemyList[0].GetComponent<EnemyDeath>().enemyLife <= 0)
				{
					enemyList[0].GetComponent<EnemyDeath>().LeftPunch();
					enemyList.RemoveAt(0);
					repositionEnemy();
				}
				else
				{
					enemyList[0].GetComponent<EnemyDeath>().enemyLife--;
				}
				PlayerDamaged();
			
			}
		    	
				getGold++;
				TimerCount();
				if (time >= 1f)
				{
					//FireBallInstatiate();
					time = 0;
				}
		}
	}

	void androidGame()
	{
		if (isGame)
		{
			
			if (Input.GetButtonDown("Fire1"))
			{
				if (Input.mousePosition.x > Screen.width/2)
				{
					player.Right();
					playerSide = true;
					if (enemyList[0].GetComponent<EnemyDeath>().enemyLife <= 0)
					{	
						enemyList[0].GetComponent<EnemyDeath>().RightPunch();
						enemyList.RemoveAt(0);
						repositionEnemy();
						RandomGold();
						PlayerLifeSteal();						
					}
					else
					{
					enemyList[0].GetComponent<EnemyDeath>().enemyLife--;
					}
				}
			
				else
				{
					player.Left();
					playerSide = false;
					if (enemyList[0].GetComponent<EnemyDeath>().enemyLife <= 0)
					{
						enemyList[0].GetComponent<EnemyDeath>().LeftPunch();
						enemyList.RemoveAt(0);
						repositionEnemy();
						RandomGold();
						PlayerLifeSteal();
						
					}
					else
					{
						enemyList[0].GetComponent<EnemyDeath>().enemyLife--;
					}
				}
				
				PlayerDamaged();
			}
			TimerCount();
			if (time >= 1f)
			{
				//FireBallInstatiate();
				time = 0;
			}
		}
		gold.text = getGold.ToString(); 
		
	}

	void PlayerLifeSteal()
	{
		if(player.comboLifePlayer >= 1)
		{
				if(player.playerLife == 1 && player.extraLifePlayer == 1)
				{
					playerComboLifeSteal++;
				}
				else if(player.playerLife == 2 && player.extraLifePlayer == 2)
				{
					playerComboLifeSteal++;
				}
				else if(player.playerLife == 3 && player.extraLifePlayer == 3)
				{
					playerComboLifeSteal++;
				}
			
			if(playerComboLifeSteal >= 10)				
			{
				if(player.playerLife == 1 && player.extraLifePlayer == 1)
				{
					player.playerLife = 2;
					player.playerLifeManagerControls[1].playerImageOn.SetActive(true);
					playerComboLifeSteal = 0;
				}
				else if(player.playerLife == 2 && player.extraLifePlayer == 2)
				{
					player.playerLife = 3;
					player.playerLifeManagerControls[2].playerImageOn.SetActive(true);
					playerComboLifeSteal = 0;
				}
				else if(player.playerLife == 3 && player.extraLifePlayer == 3)
				{
					player.playerLife = 4;
					player.playerLifeManagerControls[3].playerImageOn.SetActive(true);
					playerComboLifeSteal = 0;
				}
				
			} 
		}
		
	}
	
	void TimerCount()
	{
		time += 1 * Time.deltaTime; 
	}

	void RandomGold()
	{
		float index = Random.Range(0f,10f);
		if (index > 8 )
		{
			getGold++;
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


	void FireBallInstatiate()
	{
		int index = Random.Range(0, FireBallSpawner.Length);
		GameObject newFireBall = Instantiate (fireBall, FireBallSpawner[index].position, FireBallSpawner[index].rotation);
		
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
	
	public void PlayerDamaged()
	{
		if (enemyList[0].gameObject.CompareTag ("enemy") )
		{
			if ((enemyList[0].name == "MonsterEsq(Clone)" && !playerSide) || (enemyList[0].name == "MonsterDir(Clone)" && playerSide))
			{
				if (shieldOff == true)
				{
					DamageControl();
				}
				else 
				{
					shieldOff = true;
					player.shieldsPlayer--;
				}
				
			}
		}
	}
	public void DamageControl()
	{
		
		player.playerLife--;
		if(player.playerLife <= 3)
		{
			player.playerLifeManagerControls[3].playerImageOn.SetActive(false);
		}
		if (player.playerLife <= 2)
		{
			player.playerLifeManagerControls[2].playerImageOn.SetActive(false);
		}
		if (player.playerLife <= 1)
		{
			player.playerLifeManagerControls[1].playerImageOn.SetActive(false);
		}
		if (player.playerLife <= 0)
		{
			player.playerLifeManagerControls[0].playerImageOn.SetActive(false);
			StartCoroutine("GameOver");
		}
		
	}
	public IEnumerator GameOver()
	{
		gameOverPrefab.SetActive(true);
		gameOverPanel.SetTrigger("DoFade");
		PlayerPrefs.SetInt("gold",getGold);
		yield return new WaitForSeconds(1.5f);
		LoadingScreenManager.LoadScene(1);
	}
}
