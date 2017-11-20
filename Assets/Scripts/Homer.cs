using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homer : MonoBehaviour {

	public GameObject target;
	public float SPEED;
	public float OLD_WEIGHT = 0.5f;

	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void Update ()
	{
		Vector3 pPos = target.transform.position;
		Vector3 oldDir = transform.position;
		Vector3 toPlayer = (target.transform.position - transform.position);

		Vector3 newVel = OLD_WEIGHT * oldDir + toPlayer * (1 - OLD_WEIGHT);

		rb.velocity = toPlayer;

	}
}
