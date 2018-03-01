using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectHandler : MonoBehaviour {

    // Needed to disable panels
    public List<GameObject> panels;

    //Loads the next Scene function
    public void LoadLevel (string sceneName){
        //Load Scene based on Scene Number.
        SceneManager.LoadScene(sceneName);
	}

    // Set active to false for all panels
    public void LoadPanel(GameObject selectedPanel)
    {
        for (var i = 0; i < panels.Capacity; i++)
        {
            panels[i].SetActive(false);
        }
        selectedPanel.SetActive(true);
    }

    //The Different options panels for graphics, audio and the credits.

 //   public void GraphicsOptions (){

	//	panGraphics.SetActive (true);
	//	panAudio.SetActive (false);
	//	panCredits.SetActive (false);

	//}

	//public void AudioOptions (){

	//	panGraphics.SetActive (false);
	//	panAudio.SetActive (true);
	//	panCredits.SetActive (false);

	//}

	//public void CreditOptions (){

	//	panGraphics.SetActive (false);
	//	panAudio.SetActive (false);
	//	panCredits.SetActive (true);

	//}

	//public void ReturnToMain(){

	//	panMainMenu.SetActive (true);
	//	panGraphics.SetActive (false);
	//	panAudio.SetActive (false);
	//	panCredits.SetActive (false);
	//	panOptions.SetActive (false);
	//	panGraphics.SetActive (false);
	//	panAudio.SetActive (false);
	//	panCredits.SetActive (false);
	//	panLevelSelect.SetActive (false);
	//	panConfirm.SetActive (false);

	//}

	//public void LevelSelect()
	//{
	//	panLevelSelect.SetActive (true);
	//	panMainMenu.SetActive (false);
	//	panConfirm.SetActive (false);
	//}

	//public void EndProgram()
	//{
 //   #if UNITY_EDITOR
 //   UnityEditor.EditorApplication.isPlaying = false;
 //   #else
 //   Application.Quit();
 //   #endif
	//}

	//public void KeepPlaying()
	//{
	//	panConfirm.SetActive (false);
	//}

}