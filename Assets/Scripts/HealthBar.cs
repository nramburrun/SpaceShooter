using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthBar : MonoBehaviour 
{
	public Image currentHealthBar;
	public Text ratioText;

	private float hitPoints = 150;
	private float maxHitPoints = 150;

	public float getHealth(){ return hitPoints; }
	public float getMax() { return maxHitPoints; }

	void Start()
	{
		UpdateHealthBar ();
	}

	void UpdateHealthBar()
	{
		float ratio = hitPoints / maxHitPoints;
		currentHealthBar.rectTransform.localScale = new Vector3 (ratio, 1, 1);
		int output = Convert.ToInt32 (ratio * 100);
		ratioText.text = output.ToString () + '%';
	}

	public void TakeDamage(float damage) 
	{
		hitPoints -= damage;
		UpdateHealthBar ();
	}

	public void Heal(float heal)
	{
		hitPoints += heal;
		if (hitPoints > maxHitPoints) {
			hitPoints = maxHitPoints;
		}
		UpdateHealthBar ();
	}

}
