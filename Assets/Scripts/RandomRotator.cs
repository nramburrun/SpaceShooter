using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	private Rigidbody rb;

	public float tumble;

	void Start() 
	{
		rb = GetComponent<Rigidbody> ();

		/* Returns a random vector 3 value */
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
