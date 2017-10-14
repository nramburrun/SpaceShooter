﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour {

	public Vector2 maneuverTime;
	public Vector2 maneuverWait;
	public Vector2 startWait;
	public float dodge;
	public float smoothing;
	public float tilt;
	public Boundary boundary;

	private float currentSpeed;
	private float targetManeuver;
	private Rigidbody rb;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		currentSpeed = rb.velocity.z; /* get speed in z axis*/
		StartCoroutine (Evade ());
	}
	IEnumerator Evade() /* Co-routine */
	{
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));

		while (true) 
		{
			targetManeuver = Random.Range (3, dodge) * -Mathf.Sign(transform.position.x); /* You will dodge the other way */
			yield return new WaitForSeconds (Random.Range(maneuverTime.x, maneuverTime.y));
			targetManeuver = 0;
			yield return new WaitForSeconds (Random.Range(maneuverWait.x,maneuverWait.y));
		}
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		float newManeuver = Mathf.MoveTowards (rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
		rb.velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
		rb.position = new Vector3 
		(
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);
		 /* dat tilt tho */
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
