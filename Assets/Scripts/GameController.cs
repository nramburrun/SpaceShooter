using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject[] Hazards;
	public int hazardCount;
	public float spawnWait;
	public float waveWait;
	public float startWait;
	public Vector3 spawnValues;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;
	void Start ()
	{
		score = 0;
		gameOver = false;
		gameOverText.text = "";
		restart = false;
		restartText.text = "";
		UpdateScore ();
		StartCoroutine	(SpawnWaves());
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
			for (int i = 0; i <= hazardCount; i++) 
			{
				GameObject hazard = Hazards [Random.Range (0, Hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				/* Make a function a co-routine because c#*/
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) 
			{
				restartText.text = "Press 'R' to Restart";
				restart = true;
				break;
			}
		}
	}
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	void UpdateScore() 
	{
		scoreText.text = "Score: " + score;
	}
	public void GameOver() 
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}
}
