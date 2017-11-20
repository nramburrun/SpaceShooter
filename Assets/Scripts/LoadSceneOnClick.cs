using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public Image mMenu;
	Color FadeTo;

	public void LoadByIndex (int sceneIndex)
	{
		FadeTo = new Color (1.0f, 1.0f, 1.0f, 0f);
		mMenu.CrossFadeAlpha (0.0f, 0f, false);
		SceneManager.LoadScene (sceneIndex);
	}

}
