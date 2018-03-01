using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePageLoadLevel : MonoBehaviour {

	bool skipMessage;

	public GameObject SkipCanvas;

	private int levelNumber;

	// Update is called once per frame
	void Update () 
	{
		if (Input.anyKey)
		{
			skipMessage = true;
		}

		if (skipMessage == true)
		{
			SkipCanvas.SetActive (true);

			if (Input.GetKey (KeyCode.Return))
			{
				SkipCanvas.SetActive (false);
				levelNumber = UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex;
				levelNumber += 1;
				UnityEngine.SceneManagement.SceneManager.LoadScene(levelNumber);
			}
		}


	}


}
