using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Serializable allows you to embed a class with sub-properties (xmin etc) in the Unity Inspector */
[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, zMin, zMax;
}
	
public class PlayerController : MonoBehaviour 
{
	private Rigidbody rb;
	private AudioSource audioSource;
	private float nextFire;
	private GameObject powerUp;
	private bool hasRocket;
	private bool hasMG;
	private bool hasHP;
	private HealthBar hBar;

	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public GameObject rocketShot;
	public Transform shotSpawn; 
	public Transform rocketSpawn;
	public float fireRate;
	public float MG_duration;


	/* Getter and Setter Functions*/
	public bool getRocket() { return hasRocket; }
	public void setRocket(bool rocket) { hasRocket = rocket; }
	public bool getMG() { return hasMG; }
	public void setMG(bool machineGun) { hasMG = machineGun; }
	public bool getHP() { return hasHP; }
	public void setHP(bool healthP) { hasHP = healthP; }

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
		hasRocket = false;

		/* Find instance of the Player gameObject*/
		GameObject playerObject = GameObject.FindWithTag ("Player");
		if (playerObject != null) 
		{
			hBar = playerObject.GetComponent<HealthBar> ();
		}
	}

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			/* Set the next time where the thing will be fired*/
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			audioSource.Play ();
		}

		if (Input.GetButton ("Fire2") && hasRocket && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate (rocketShot, rocketSpawn.position, rocketSpawn.rotation);
			hasRocket = false;
		}
		if (Input.GetButton ("Fire2") && hasMG) 
		{
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			StartCoroutine (PUOff ());
		}	
	}
		
	/* Setup Physics things */
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.velocity = movement*speed;
		/* Limit the position of the player*/
		rb.position = new Vector3 
	    (
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 
			0.0f,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax) 
		);
		 /* Set the tilt of the ship */
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x *-tilt);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "PURocket") 
		{
			hasRocket = true;
			powerUp = GameObject.FindGameObjectWithTag ("PURocket");
			powerUp.SetActive (false);
			Destroy (powerUp);
		}
		if (other.tag == "PUMachineGun") 
		{
			hasMG = true;
			powerUp = GameObject.FindGameObjectWithTag ("PUMachineGun");
			powerUp.SetActive (false);
			Destroy (powerUp);
		}
		if (other.tag == "PUHealthP") 
		{
			hBar.Heal (10);
			powerUp = GameObject.FindGameObjectWithTag ("PUHealthP");
			if (hBar.getHealth () < hBar.getMax ()) 
			{
				powerUp.SetActive (false);
				Destroy (powerUp);
			}
		}
	}

	IEnumerator PUOff()
	{
		yield return new WaitForSeconds (MG_duration);
		hasRocket = false;
		hasMG = false;
	}
}
