﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		//Destrot everything that leaves the collider
		if (other.tag != "Asteroid") 
		{
			Destroy(other.gameObject);
		}
	}
}
