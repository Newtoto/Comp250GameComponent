using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelFromCompletion : MonoBehaviour {

	private int levelNumber;

	public void NextLevelLoad()
	{
		levelNumber = UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex;
		levelNumber += 1;
		UnityEngine.SceneManagement.SceneManager.LoadScene(levelNumber);
	}

}