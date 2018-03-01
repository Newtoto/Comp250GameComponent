using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainbowShield : MonoBehaviour {

    public SpriteRenderer ColorRef;

    private Color Rainbow;

    private Color lastColor;

    // Use this for initialization
    void Start() {
        Rainbow.a = 255;
    }

    Color ChangeColor()
    {
        Rainbow.r = Random.Range(50, 225);
        Rainbow.g = Random.Range(50, 225);
        Rainbow.b = Random.Range(50, 225);

        return Rainbow;
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        Rainbow = ChangeColor();
        ColorRef.color = Color.Lerp(lastColor, Rainbow, 2.0f);
        lastColor = Rainbow;
    }
}
