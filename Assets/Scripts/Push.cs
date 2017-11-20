using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour {
	
	public float speed;
	public float minSpeed;
	public float maxSpeed;

	private Rigidbody rb;
	private int rSign;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		Vector3 rVel = new Vector3 (Random.Range (0 , 2),
			0, Random.Range (minSpeed,maxSpeed));

		rSign = Random.Range (1, 10);
		if (rSign < 2) 
		{
			rVel.x = -1 * rVel.x;
		} else 
		{
			rVel.z = -1 * rVel.z;
		}
		rb.velocity = rVel * speed;
	}

}
