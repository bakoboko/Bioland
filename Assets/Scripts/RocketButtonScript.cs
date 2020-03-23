using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketButtonScript : MonoBehaviour {
    public static bool rocketButton;
    private bool changeColor;
    private Renderer rend;


	void Update()
    {
        if (RocketArmBarricadeScript.hasMoved == true)
        {
            changeColor = true;
        }

        if(changeColor == true)
        {
            transform.Find("ButtonColor").GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
