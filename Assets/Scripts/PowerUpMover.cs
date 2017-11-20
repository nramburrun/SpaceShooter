using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMover : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		rb.velocity = -1*transform.forward * speed;
	}
}
