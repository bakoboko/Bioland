using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScanScript : MonoBehaviour {

    private GameObject player;
    private Transform[] children;
    private Transform door;
    private Transform scanner;
    private ModuleManagementScript moduleManager;
    private bool moveDown;
    private bool hasOpened;
    private Vector3 startPos;

	
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        moduleManager = player.gameObject.GetComponent<ModuleManagementScript>();

        children = transform.parent.gameObject.GetComponentsInChildren<Transform>();
        foreach(Transform child in children)
        {
            if(child.name == "Slider")
            {
                door = child;
            }
            if(child.name == "Scanner")
            {
                scanner = child;
            }
        }
        startPos = door.transform.position;
	}

    void Update()
    {
        Open();
    }

	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("Press E");      
        }
    }

    void OnTriggerStay()
    {
            if (Input.GetKey(KeyCode.E))
            {
                if (moduleManager.disguiseHeadActive == true)
                {
                moveDown = true;
                   
                }
                else
                {
                    Fail();
                }
            }
    }

    void Open()
    {
        if (moveDown == true && hasOpened == false)
        {
            scanner.GetComponent<Renderer>().material.color = Color.blue;
            door.transform.Translate(Vector3.down / 10);
            if (door.transform.position.y < startPos.y - 5)
            {
                scanner.GetComponent<Renderer>().material.color = Color.green;
                moveDown = false;
                hasOpened = true;
            }
        }

    }

    void Fail()
    {
        print("ALERT!");
    }
}
