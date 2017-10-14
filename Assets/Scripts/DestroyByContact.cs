using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	private GameController gameController;
	public int scoreValue;

	void Start()
	{
		/* Find an instance to the game controller object*/
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find GameController Script");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		/* Necessary for the trigger logic to not destroy boundary and the asteroid upon spawning */
		if (other.tag == "Boundary" || other.tag == "Enemy" ||
			other.tag == "BouncyCastle" || other.tag == "Asteroid" 
			|| other.tag == "miniAst")
		{
			return;
		}

		if (explosion != null) 
		{
			Instantiate (explosion, transform.position, transform.rotation);
		}

		if (other.tag == "Player") 
		{		
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}
		/* Destroy the bolt */
		Destroy (other.gameObject);
		/* Destroy Asteroid - since its the game object the script is attached to */

		//gameController.AddScore(scoreValue);
		Destroy (gameObject);
	}
}
