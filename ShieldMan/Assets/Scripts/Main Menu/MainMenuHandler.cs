using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour {

	public GameObject panMainMenu;
	public GameObject panLevelSelect;
	public GameObject panOptions;
	public GameObject panGraphics;
	public GameObject panAudio;
	public GameObject panCredits;
	public GameObject panConfirm;

	//Loads the next Scene function
	public void LoadNextScene (int SceneNumber){
		//Load Scene based on Scene Number.
		SceneManager.LoadScene (SceneNumber);
	}

	//Ends the program
	public void EndProgramConfirm (){
		panConfirm.SetActive (true);
	}

	public void LoadOptions (){

		panMainMenu.SetActive (false);
		panOptions.SetActive (true);
		panGraphics.SetActive (true);
		panAudio.SetActive (false);
		panCredits.SetActive (false);
		panConfirm.SetActive (false);

	}

	//The Different options panels for graphics, audio and the credits.

	public void GraphicsOptions (){

		panGraphics.SetActive (true);
		panAudio.SetActive (false);
		panCredits.SetActive (false);

	}

	public void AudioOptions (){

		panGraphics.SetActive (false);
		panAudio.SetActive (true);
		panCredits.SetActive (false);

	}

	public void CreditOptions (){

		panGraphics.SetActive (false);
		panAudio.SetActive (false);
		panCredits.SetActive (true);

	}

	public void ReturnToMain(){

		panMainMenu.SetActive (true);
		panGraphics.SetActive (false);
		panAudio.SetActive (false);
		panCredits.SetActive (false);
		panOptions.SetActive (false);
		panGraphics.SetActive (false);
		panAudio.SetActive (false);
		panCredits.SetActive (false);
		panLevelSelect.SetActive (false);
		panConfirm.SetActive (false);

	}

	public void LevelSelect()
	{
		panLevelSelect.SetActive (true);
		panMainMenu.SetActive (false);
		panConfirm.SetActive (false);
	}

	public void EndProgram()
	{
    #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
    #else
    Application.Quit();
    #endif
	}

	public void KeepPlaying()
	{
		panConfirm.SetActive (false);
	}

}