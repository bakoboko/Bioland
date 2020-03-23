using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCScript : MonoBehaviour {
    public static bool menuOpen = false;

    void Start()
    {
     
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ("Player") && PlayerCharacterScript.isLookingAtButton == true)
        {
            print("Press E");

            if (Input.GetKeyDown(KeyCode.E) && menuOpen == false)
            {
                PlayerCharacterScript.moduleUI.SetActive(true);
                menuOpen = true;
            }
        }
    }
}
