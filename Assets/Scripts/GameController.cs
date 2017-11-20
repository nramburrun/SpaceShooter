using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject[] Hazards;
	public GameObject powerUpScript;
	public GameObject BouncyCastle;
	public GameObject[] HazardsWITHMINI;
	private GameObject hazard;

	public float GOAL1;
	public float GOAL2;
	public float GOAL3;
	public float spawnWait;
	public float waveWait;
	public float startWait;
	public Vector3 spawnValues;
	public float miniCount;
	public float spawnRadius;
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool miniSpawn;
	private bool isActive = false;
	private int numDestroyed;
	private bool restart;
	private bool isWave1;
	private bool isWave2;
	private int score;
	public int spawnNum;
	private int waveNum;
	private int PU_total;
	private float choice;
	private Vector3 lastRecorded;
	private Vector3 offset;
	private SpawnMini sMini;

	void Start ()
	{
		offset = new Vector3 (0,0,0);
		score = 0;
		waveNum = 1;
		gameOver = false;
		gameOverText.text = "Wave " + waveNum;
		restart = false;
		miniSpawn = false;
		restartText.text = "";
		scoreText.text = "Score: " + score;
		startSpawn ();
	}

	void startSpawn()
	{
		StartCoroutine(SpawnWaves());
		if (miniSpawn) 
		{

		}
	}

	void Update()
	{
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while(true)
		{
			gameOverText.text = "";
			for (int i = 0; i < spawnNum; i++) 
			{
				if (miniSpawn) {
					hazard = HazardsWITHMINI [Random.Range (0, HazardsWITHMINI.Length)];
				} else {
					 hazard = Hazards [Random.Range (0, Hazards.Length)];
				}
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				/* Make a function a co-routine because c#*/
				yield return new WaitForSeconds (spawnWait);
			}
			/* Function checks if it's ready to spawn powerups*/
			SpawnPowerUps ();
			SpawnBabies ();
			BouncyCastleOn ();
			if (gameOver) 
			{
				restartText.text = "Press 'R' to Restart";
				gameOverText.text = "Game Over";
				restart = true;
				break;
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
		
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	void UpdateScore() 
	{
		numDestroyed++;
		scoreText.text = "Score: " + score;
	}
	public void GameOver() 
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}

	public bool isGameOver()
	{
		return gameOver;
	}
		
	bool IsEmpty()
	{
		GameObject[] GAMEOBJ = GameObject.FindGameObjectsWithTag ("Asteroid");
		if (GAMEOBJ.Length == 0)
			return true;
		for (int i = 0; i < GAMEOBJ.Length; i++) 
		{
			if (GAMEOBJ [i].activeInHierarchy)
				continue;
			else
				return true;
		}
		return false;
	}

	void UpdateParams()
	{
		spawnNum += 4;
	}

	void SpawnPowerUps()
	{
		if (numDestroyed >= GOAL1) 
		{
			if (!powerUpScript.activeInHierarchy) 
			{
				gameOverText.text = "I'll help you out a little bit..";
				powerUpScript.SetActive (true);
				spawnWait = spawnWait / 2;
				UpdateParams ();
			}
		}
	}

	void SpawnBabies()
	{
		if (numDestroyed >= GOAL2 && !isActive) 
		{
			miniSpawn = true;
			gameOverText.text = "Space Babies";
			isActive = true;
		}
	}

	void BouncyCastleOn()
	{
		if (numDestroyed >= GOAL3) 
		{
			if (!BouncyCastle.activeInHierarchy) 
			{
				gameOverText.text = "You dun goofed";
				BouncyCastle.SetActive (true);
			}
		}
	}
}
