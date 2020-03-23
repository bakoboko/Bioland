using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpening : MonoBehaviour {

    private GameObject door;
    private Vector3 startPos;
    private bool hasOpened;
    private bool allowOpen;
	
	
    void Start()
    {
        door = GameObject.FindGameObjectWithTag("slidingDoor");
        hasOpened = false;
        startPos = door.transform.position;
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == ("Player"))
        {
            print("Press E");
            if (Input.GetKey(KeyCode.E) && AlertBoardScript.openDoor == true)
            {
                allowOpen = true;
            }
            else
            {
                print("You need more buttons");
            }
        }
    }

	void Update ()
    {
        OpenDoor();
	}

    void OpenDoor()
    {
        if (AlertBoardScript.openDoor == true && allowOpen == true && hasOpened == false)
        {
            GameObject.FindGameObjectWithTag("slideDoorScanner").GetComponent<Renderer>().material.color = Color.blue;
            door.transform.Translate(Vector3.down / 10);
            if (door.transform.position.y < startPos.y - 4.5)
            {
                GameObject.FindGameObjectWithTag("slideDoorScanner").GetComponent<Renderer>().material.color = Color.green;
                allowOpen = false;
                hasOpened = true;
            }
        }
    }
}
