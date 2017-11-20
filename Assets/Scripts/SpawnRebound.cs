using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Writing this myself */
public class SpawnRebound : MonoBehaviour {

	public float FORCE;
	public GameObject playerObj;

	private Rigidbody rb;
	private Vector3 startPoint;
	private Vector3 endPoint;

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
			Vector3 PlayerPos = playerObj.transform.position;
			Vector3 curPos = gameObject.transform.position;

			/* Gets the sum of the directions to know where the final direction will be*/
			Vector3 currentDir = curPos.normalized;
			Vector3 desiredDir = (curPos - PlayerPos).normalized;

			rb.velocity = -1*FORCE*(currentDir + desiredDir);
			
		}
	}
}
