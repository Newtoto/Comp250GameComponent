using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollingText : MonoBehaviour
{

    public float letterPaused = 0.01f;
    public string message;
    Text introText;

    // Use this for initialization
    void OnEnable()
    {

        introText = GetComponent<Text>();
        introText.text = message;
        introText.text = "";
        StartCoroutine(TypeText());

    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            introText.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPaused);
        }
    }
}
