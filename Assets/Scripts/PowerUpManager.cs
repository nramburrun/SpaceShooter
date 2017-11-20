using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

	public GameObject[] powerUps;
	public float Prob_MG;
	public float Prob_Rocket;
	public float Prob_Health;
	public Vector3 spawnValues;	
	public float spawninterval;
	public float PU_spawnWait; 

	private GameController gameController;
	private int PU_total;
	private int choice;
	private int timeElapsed;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		StartCoroutine (SpawnPowerUps ());
	}

	IEnumerator SpawnPowerUps()
	{
		yield return new WaitForSeconds (PU_spawnWait);
		while(true)
		{
			for (int i = 0; i < powerUps.Length; i++) 
			{
				GameObject spawnPU = powerUps [Random.Range (0, powerUps.Length)];
				choice = (Random.Range (0, PU_total));
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (spawnPU, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawninterval);
			}
			yield return new WaitForSeconds (spawninterval);
		}
						/* Some other kind of implementation for powerupss */
			//			if (choice > (100 - Prob_MG)) {
			//				Debug.Log ("why");
			//				Instantiate (powerUps_Weapons [0], spawnPosition, spawnRotation);
			//				continue;
			//			} else if (choice > (100 - Prob_Health)) {
			//				Instantiate (powerUps_Utils [0], spawnPosition, spawnRotation);
			//				continue;
			//			} else if (choice > (100 - Prob_Rocket)) {
			//				Instantiate (powerUps_Weapons [1], spawnPosition, spawnRotation);
			//				continue;
			//			} else
			//				continue;
			//			if (gameController.isGameOver()) 
			//			{
			//				break;
			//			}

	}
}
