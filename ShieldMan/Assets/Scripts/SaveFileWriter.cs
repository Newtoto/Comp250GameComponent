using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class SaveFileWriter : MonoBehaviour {

    public int amountOfStars;
    public string path = "Assets/TextFiles/SaveFile.txt";
        
    StreamReader reader;
    StreamWriter writer;

    string level1;
    int temp;
    string xyz;
    string[] xyz1;

   // List<string> lines;

    private void Start()
    {
        List<string> lines = File.ReadAllLines(path).ToList();
        level1 = lines[0];
        Debug.Log(level1);
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.O))
        {
            StarCountUp();
        }
        if (Input.GetKeyDown(KeyCode.L))
            Debug.Log(level1);
        if (Input.GetKeyDown(KeyCode.Keypad1))
            EndLevelSave(1, temp, 3, 4);
            
    }

    private void StarCountUp ()
    {
        string[] starsplit = level1.Split(' ');
        int.TryParse(starsplit[3], out temp);
        temp++;
        starsplit[3] = temp.ToString();
        level1 = starsplit[0] + " " + starsplit[1] + " " + starsplit[2] + " " + temp + " " + starsplit[4] + " " +starsplit[5] + " " + starsplit[6] + " " + starsplit[7];        

    }

    public void EndLevelSave (int level,int stars, float time, int complete)
    {
        writer = new StreamWriter(path);
        writer.Write("Level: " + level + " " + "Stars: " + stars + " " + "Time: " + time + " " + "Complete: " + complete);
        writer.Close();
    }
}
