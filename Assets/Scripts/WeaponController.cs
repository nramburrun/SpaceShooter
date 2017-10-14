using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate_low;
	public float fireRate_high;
	public float delay; 
	private float rand;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		rand = Random.Range (fireRate_low, fireRate_high);
		Debug.Log (rand.ToString("F1"));
		audioSource = GetComponent<AudioSource> ();
		InvokeRepeating ("Fire", delay, rand);
	}

	void Fire()
	{
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		audioSource.Play ();
	}
}
