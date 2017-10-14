using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour {
	
	public float speed;

	private Rigidbody rb;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		Vector3 rVel = new Vector3 (Random.Range (-1, 1),
			               0, Random.Range (-1, 1));
		rb.velocity = rVel * speed;

	}

}
