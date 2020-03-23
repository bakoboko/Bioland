using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreCountScript : MonoBehaviour {
    public Text text;
    private float newScore;
    private float finalScore;
	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {

        finalScore = PlayerCharacterScript.score * 254 / 66;
        text.text = ("Score = " + finalScore);

    }
}
