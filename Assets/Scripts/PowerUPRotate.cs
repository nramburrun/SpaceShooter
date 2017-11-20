using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPRotate : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (45, 45, 40) * Time.deltaTime);
	}
}
