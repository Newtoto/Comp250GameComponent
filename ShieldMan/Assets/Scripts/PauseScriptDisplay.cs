using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScriptDisplay : MonoBehaviour {

	private bool gamePaused;

	private GameObject PanPauseMenuUI;

	void Start()
	{
		PanPauseMenuUI = GameObject.Find ("PanPauseMenu");
		PanPauseMenuUI.SetActive (false);
	}


void FixedUpdate () 
	{
		if (Input.GetKey (KeyCode.Escape))
		{
			Time.timeScale = 0;
			PanPauseMenuUI.SetActive (true);
		}
	}

	public void resumePlay ()
	{
		Time.timeScale = 1;
		PanPauseMenuUI.SetActive (false);

	}

	public void returntoMenu ()
	{
		Time.timeScale = 1;
		UnityEngine.SceneManagement.SceneManager.LoadScene (0);
	}

}
