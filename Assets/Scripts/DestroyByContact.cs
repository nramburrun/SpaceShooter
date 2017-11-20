using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject rocketExplosion;
	public GameObject playerExplosion;
	private GameController gameController;
	private HealthBar hBar;
	private float damage;
	private PlayerController rPU;
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

		/* Find instance of the Player gameObject*/
		GameObject playerObject = GameObject.FindWithTag ("Player");
		if (playerObject != null) 
		{
			hBar = playerObject.GetComponent<HealthBar> ();
			rPU = playerObject.GetComponent<PlayerController> ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		/* Necessary for the trigger logic to not destroy boundary and the asteroid upon spawning */
		if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "EnemyBolt" 
			|| other.tag == "BouncyCastle" || other.tag == "Asteroid" 
			|| other.tag == "miniAst" || other.tag == "PUSphere" || other.tag == "PURocket"
			|| other.tag == "PUMachineGun" || other.tag == "PUHealthP")
		{
			return;
		}

		if (explosion != null) 
		{
			Instantiate (explosion, transform.position, transform.rotation);
		}

		if (other.tag == "Player") 
		{	
		/*	Instead of destroying, let us see it take damage.
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		*/
			if (gameObject.tag == "miniAst") 
			{
				damage = 5;
			} 
			else if (gameObject.tag == "EnemyBolt") 
			{
				damage = 25;
				Destroy (gameObject);
			} 
			else 
			{
				damage = 15;
			}

			hBar.TakeDamage (damage);
			if (hBar.getHealth() <= 0.0f) 
			{
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				gameController.GameOver ();
			} 
			else 
			{
				return;
			}
		}

		if (other.tag == "Rocket") 
		{
			Instantiate (rocketExplosion, transform.position, transform.rotation);
			Destroy (gameObject);
			gameController.AddScore(scoreValue);
			rPU.setRocket (false);
			return;
		}
		/* Destroy the bolt */
		Destroy (other.gameObject);
		/* Destroy Asteroid - since its the game object the script is attached to */
		Destroy (gameObject);
		gameController.AddScore(scoreValue);
	}
}
