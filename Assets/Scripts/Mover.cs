﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private GameController gameController;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.forward * speed;
	
	}
}
