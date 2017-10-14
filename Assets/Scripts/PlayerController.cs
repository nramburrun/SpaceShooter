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

	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn; 
	public float fireRate;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
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
}
