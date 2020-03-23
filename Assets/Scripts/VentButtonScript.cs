using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentButtonScript : MonoBehaviour {
    private bool changeColor;
    public static bool ventButton;

    void Update()
    {
        if (changeColor == true)
        {
           transform.Find("ButtonColor").GetComponent<Renderer>().material.color = Color.green;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ("Player") && PlayerCharacterScript.isLookingAtButton == true)
        {
            print("Press E");

            if (Input.GetKeyDown(KeyCode.E))
            {
                ventButton = true;
                changeColor = true;
            }

        }
    }
}
