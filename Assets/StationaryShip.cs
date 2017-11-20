using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryShip : MonoBehaviour {

	public GameObject placement;

	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.MovePosition (placement.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
