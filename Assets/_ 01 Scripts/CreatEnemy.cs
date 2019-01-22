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

	[SerializeField]
	Animator[] spikesAnin;
	[SerializeField]
	GameObject spike;

	

	[Header ("Game Over System")]
	[SerializeField]
	GameObject gameOverPrefab;
	[SerializeField]
	Animator gameOverPanel;

	float gameTime;
	float bestTime;
	float monsterTime;
	float fireBallTime;
	float spikeTime;
	float powerDestructionTime;
	int enemyCount;
	[HideInInspector]
	public bool shieldOff;
	[HideInInspector]
	public bool doDestruction;
	bool level2 = false;

	[HideInInspector]
	public List <GameObject> enemyList;
	
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
		gameTime = PlayerPrefs.GetFloat("timePlayed");
		enemyCount = PlayerPrefs.GetInt("enemyNumber");
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
				if (fireBallTime >= 1f)
				{
					//FireBallInstatiate();
					fireBallTime = 0;
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
					if (doDestruction)
					{
						enemyCount++;	
						enemyList[0].GetComponent<EnemyDeath>().RightPunch();
						enemyList.RemoveAt(0);
						repositionEnemy();
						RandomGold();
						PlayerLifeSteal();
			
					}
					else if (enemyList[0].GetComponent<EnemyDeath>().enemyLife <= 0)
					{	
						enemyCount++;	
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
					if(doDestruction)
					{
						enemyCount++;	
						enemyList[0].GetComponent<EnemyDeath>().LeftPunch();
						enemyList.RemoveAt(0);
						repositionEnemy();
						RandomGold();
						PlayerLifeSteal();
						
					}
					else if (enemyList[0].GetComponent<EnemyDeath>().enemyLife <= 0)
					{
						enemyCount++;	
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
			//Timer Manager System:
			GameLevelManager();
			if (doDestruction)
			{
				if (powerDestructionTime >= 3f)
				{
					doDestruction = false;
					player.powerDestructionPlayer--;
					player.newPower.SetActive(false);
				}
			}
			if(monsterTime > 30f)
			{
				SoundManager.instance.Play("Player",SoundManager.instance.clipList.monsterScream,1f);
				monsterTime = 0;
			}
			
		}
		gold.text = getGold.ToString(); 
		//save enemy number:
		PlayerPrefs.SetInt("enemyNumber",enemyCount);
		Debug.Log(playerComboLifeSteal);
	}

	void GameLevelManager()
	{
		if(bestTime > 1f && level2 == false)
		{

			if (fireBallTime >= 1f)
			{
				FireBallInstatiate();
				fireBallTime = 0;
			}
		} 
		if(bestTime > 60f)
		{
			level2 = true;
			if(spikeTime > 1f)
			{
				SpikeInstantiate();
				spikeTime = 0;
			}
			
		} 
		if (bestTime > 90)
		{

			if (fireBallTime >= 1f)
			{
				FireBallInstatiate();
				fireBallTime = 0;
			}
			if(spikeTime > 1f)
			{
				SpikeInstantiate();
				spikeTime = 0;
			}
		}
	}
	void PlayerLifeSteal()
	{
		if(player.comboLifePlayer >= 1)
		{
				if(player.playerLife < 2 && player.extraLifePlayer == 1)
				{
					playerComboLifeSteal++;
				}
				if(player.playerLife < 3 && player.extraLifePlayer == 2)
				{
					playerComboLifeSteal++;
				}
				if(player.playerLife < 4 && player.extraLifePlayer == 3)
				{
					playerComboLifeSteal++;
				}
			
				if(playerComboLifeSteal >= 5)				
				{
					playerComboLifeSteal = 0;
					if(player.playerLife == 1)
					{
						player.playerLife = 2;
						player.playerLifeManagerControls[1].playerImageOn.SetActive(true);
						
					}
					else if(player.playerLife == 2 )
					{
						player.playerLife = 3;
						player.playerLifeManagerControls[2].playerImageOn.SetActive(true);
						
					}
					else if(player.playerLife == 3 )
					{
						player.playerLife = 4;
						player.playerLifeManagerControls[3].playerImageOn.SetActive(true);
					}
					
				} 
		}
		
	}
	
	void TimerCount()
	{
		gameTime += 1 * Time.deltaTime;
		PlayerPrefs.SetFloat("timePlayed",gameTime);
		bestTime += 1 * Time.deltaTime;
		if(bestTime > PlayerPrefs.GetFloat("bestTimePlayed"))
		{
			PlayerPrefs.SetFloat("bestTimePlayed",bestTime);
		}
		monsterTime += 1 * Time.deltaTime;
		fireBallTime += 1 * Time.deltaTime; 
		spikeTime += 1 * Time.deltaTime;
		powerDestructionTime += 1 * Time.deltaTime;
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
	void SpikeInstantiate()
	{
		StartCoroutine("Spikes");
	}

	IEnumerator Spikes()
	{
		int index = Random.Range(0, 10);
		yield return new WaitForSeconds(0.5f);
		if (index < 5)
		{
			spikesAnin[0].SetTrigger("doSpike");
		}
		else
		{
			spikesAnin[1].SetTrigger("doSpike");
		}
		
		
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
					player.DamageControl();

				}
				else 
				{
					shieldOff = true;
					player.shieldsPlayer--;
					player.newShield.SetActive(false);
				}
				
			}
		}
	}
	
	public IEnumerator GameOver()
	{
		isGame = false;
		gameOverPrefab.SetActive(true);
		gameOverPanel.SetTrigger("DoFade");
		PlayerPrefs.SetInt("gold",getGold);
		yield return new WaitForSeconds(1.5f);
		LoadingScreenManager.LoadScene(1);
	}
}
