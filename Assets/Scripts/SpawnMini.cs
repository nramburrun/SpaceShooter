using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMini : MonoBehaviour {
	
	public GameObject[] miniHazards;
	private Vector3 lastRecorded;
	public float miniCount;
	public float spawnRadius;
	private Vector3 offset;

	void Start()
	{
		offset = new Vector3 (0,0,0);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Bullet") 
		{
			lastRecorded = gameObject.transform.position;
			StartCoroutine (SpawnMinis());

			/* If it's active, spawn a number of mini asteroids 
			 - look at game controller script to figure out how to do the spawn thing
			 - Spawn them in a circle and assign them random outward velocities */
		}
	}
	IEnumerator SpawnMinis()
	{
		
		for (int i = 0; i < miniCount; i++) 
		{
			GameObject mini = miniHazards [Random.Range (0, miniHazards.Length)];
		    Vector3 miniPosition = SpawnCircle(lastRecorded,spawnRadius,i);
			Quaternion miniRot = Quaternion.identity;
			miniPosition.x = miniPosition.x + offset.x;
			miniPosition.z = miniPosition.z + offset.z;
			Instantiate (mini, miniPosition, miniRot);
			//offset.x = Random.insideUnitSphere.x;
			//offset.z = Random.insideUnitSphere.z;
		}
		yield return null;

	}

	Vector3 SpawnCircle (Vector3 objCenter, float radius, int count)
	{
		Debug.Log (count);
		float angle = ((float)(count)/4.0f) * 360;
		Debug.Log (angle);
		Vector3 sPos;
		sPos.x = objCenter.x + (radius * Mathf.Cos (angle * Mathf.Deg2Rad));
		sPos.z = objCenter.z + (radius * Mathf.Sin (angle * Mathf.Deg2Rad));
		sPos.y = objCenter.y;

		return sPos;
	}
}
