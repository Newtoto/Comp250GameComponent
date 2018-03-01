using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif 
public class StarOptions : MonoBehaviour {
#if UNITY_EDITOR
    [ExecuteInEditMode()]
    //Stars to get
    public bool Star1, Star2, Star3;
    //Types to get Stars
    public bool Time, Objectives, Collectibles;
    //Floats for time values
    public float oneStarTime, twoStarTime, threeStarTime;
    //Objects for Stars
    public GameObject oneStarObj;
    public GameObject twoStarObj;
    public GameObject threeStarObj;

    public int optionTabsInt = 0;


    public void Awake()
    {
        oneStarObj = GameObject.Find("Star1");
        twoStarObj = GameObject.Find("Star2");
        threeStarObj = GameObject.Find("Star3");
        GameObject.Find("PanLevelComp").SetActive(false);
        if (oneStarObj == null)
            Debug.LogError("Cant Find the Star!!");
    }


    public void Timing(float time)
    {
        if (Time)
        {
            if (!Star1 && time < oneStarTime)
            {
                Star1 = true;
                oneStarObj.GetComponent<Image>().color = Color.yellow;
            }
                

            if (!Star2 && time < twoStarTime)
            {
                Star2 = true;
                twoStarObj.GetComponent<Image>().color = Color.yellow;
            }
                

            if (!Star3 && time < threeStarTime)
            {
                Star3 = true;
                threeStarObj.GetComponent<Image>().color = Color.yellow;
            }
                
        }

        Debug.LogWarning("Star 1 = " + Star1 + " Star 2 = " + Star2 + " Star 3 = " + Star3);
    }
#endif

}
