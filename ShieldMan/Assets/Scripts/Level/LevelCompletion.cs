using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour {

	public GameObject uI;
	public GameObject levelCompleteUI;

    private GameObject levelController;
    public GameObject Timer;

	private int levelNumber;

	void Start ()
	{

        levelController = GameObject.Find("LevelController");
        
		if (uI == null)
		{
			uI = GameObject.Find ("PanGameUI");
		}

		if (levelCompleteUI == null)
		{
			levelCompleteUI = GameObject.Find ("PanLevelComp");
			levelCompleteUI.SetActive (false);
		}
		Time.timeScale = 1;
	}
		
	void OnCollisionEnter2D (Collision2D Collision) 
	{
		if (Collision.gameObject.tag == "Player")
		{
			levelCompleteUI.SetActive (true);
			uI.SetActive (false);
			Time.timeScale = 0;
            
            levelController.GetComponent<StarOptions>().Timing(Timer.GetComponent<LevelTimer>().time);
		}
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Return))
		{
			levelNumber = UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex;
			levelNumber += 1;
			UnityEngine.SceneManagement.SceneManager.LoadScene(levelNumber);
		}
	}
}