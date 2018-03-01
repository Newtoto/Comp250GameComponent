using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextLevel : MonoBehaviour {

	private int levelNumber;
	// Use this for initialization
	void OnCollisionEnter2D (Collision2D Collision) 
	{
		levelNumber = UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex;
		levelNumber += 1;
		UnityEngine.SceneManagement.SceneManager.LoadScene(levelNumber);
	}
}
