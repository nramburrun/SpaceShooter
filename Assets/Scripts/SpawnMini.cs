using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMini : MonoBehaviour {
	
	public GameObject[] miniHazards;
	private Vector3 lastRecorded;
	public float startWait;
	public float miniCount;
	public float miniWait;
	public float miniSpeed;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Bullet") 
		{
			lastRecorded = gameObject.transform.position;
			StartCoroutine (SpawnMinis ());

			/* If it's active, spawn a number of mini asteroids 
			 - look at game controller script to figure out how to do the spawn thing
			 - Spawn them in a circle and assign them random outward velocities */
		}
	}
	IEnumerator SpawnMinis()
	{
		for (int i = 0; i <= miniCount; i++) 
		{
			GameObject mini = miniHazards [Random.Range (0, miniHazards.Length)];
		    Vector3 miniPosition = SpawnCircle(lastRecorded,1.0f);
			Quaternion miniRot = Quaternion.identity;
			Instantiate (mini, miniPosition, miniRot);
		}
		yield return new WaitForSeconds (miniWait);
		yield return null;

	}

	Vector3 SpawnCircle( Vector3 objCenter, float radius)
	{
		float angle = Random.value * 360;
		Vector3 sPos;
		sPos.x = objCenter.x + (radius * Mathf.Cos (angle * Mathf.Deg2Rad));
		sPos.z = objCenter.z + (radius * Mathf.Sin (angle * Mathf.Deg2Rad));
		sPos.y = objCenter.y;

		return sPos;
	}
}
