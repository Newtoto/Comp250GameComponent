using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveLoadData : MonoBehaviour {

    // Change this for whatever script needs the time
    public float [] bestTimes;

    private string currentLevelName;
    private int worldNumber;
    private int levelNumber;

    // Used to save time in correct place in array
    private int worldSize = 5;

    void SaveLevelTime(float time)
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream fStream = File.Create(Application.persistentDataPath + "/playerSave.sav");

        // Create object to save
        SaveManager saver = new SaveManager();

        // Get string array of level name e.g. level 1-1 is [1, -, 1]
        currentLevelName = SceneManager.GetActiveScene().name;

        // Convert world and level number chars to ints
        worldNumber = currentLevelName[0] - '0';
        // currentLevelName[1] is the hyphon so is ignored
        levelNumber = currentLevelName[2] - '0';

        // Array position of level time calculated with worldSize(W-1)+L - 1
        int levelPositionInArray = worldSize * (worldNumber - 1) + levelNumber - 1;

        // Check if time hasn't been set, or if time is better than previous
        if(bestTimes[levelPositionInArray] > time || bestTimes[levelPositionInArray] == 0)
        {
            // Overwrite time in local array
            bestTimes[levelPositionInArray] = time;
        }

        // Overwrite save file with new data
        saver.bestTimes = bestTimes;

        // Save new SaveManager to file
        binary.Serialize(fStream, saver);
        fStream.Close();
    }

    void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerSave.sav"))
        {
            // Load player save file
            BinaryFormatter binary = new BinaryFormatter();
            FileStream fStream = File.Open(Application.persistentDataPath + "/playerSave.sav", FileMode.Open);
            SaveManager saver = (SaveManager)binary.Deserialize(fStream);
            bestTimes = saver.bestTimes;
            fStream.Close();

        }
    }

	// Use this for initialization
	void Start () {
        Load();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Saving file");
            SaveLevelTime(1.37f);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("Loading file");
            Load();
        }
    }
}

[Serializable]
class SaveManager
{
    // Array containting all level times in order
    public float[] bestTimes = new float[20];

    /* 
    How the level times are saved
    [1-1, 1-2, 1-3, 1-4, 1-5,
     2-1, 2-2, 2-3, 2-4, 2-5,
     3-1, 3-2, 3-3, 3-4, 3-5,
     4-1, 4-2, 4-3, 4-4, 4-5]
    */
}