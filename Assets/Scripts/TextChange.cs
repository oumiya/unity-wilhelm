using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour {

    private Text targetText;

	// Use this for initialization
	void Start () {
        SetText();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetText()
    {
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = "High Score:" + GameController.highScore.ToString();
    }
}
