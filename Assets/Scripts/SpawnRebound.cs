using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Writing this myself */
public class SpawnRebound : MonoBehaviour {

	public float forceMult;

	private Rigidbody rb;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
	}

	void OnTriggerEnter(Collider other)
	{
		/* TO DO - Basically, I want to rebound the hazards off the bottom of the map. Make sure that this thing can be turned off so you can turn it into a level
		- Use the current objects that have been spawned originally and just rebound. There's no point in instantiating more hazards.
		*/
		if (other.tag == "BouncyCastle")
		{
			rb.AddForce (-forceMult*Vector3.Reflect(rb.velocity,
				Vector3.up), ForceMode.Impulse);
		}
	}
}
