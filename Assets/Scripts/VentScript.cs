using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentScript : MonoBehaviour {

    private GameObject player;
    private Renderer vent;
    private ModuleManagementScript moduleManager;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        moduleManager = player.gameObject.GetComponent<ModuleManagementScript>();
	}
	
	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Player"))
        {
            print("Press E");
            
        }
    }

    void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (moduleManager.ventArmsActive == true)
            {
                VentUnlock();
            }
            else
            {
                print("Failed");
            }
        }
    }

    void VentUnlock()
    {
        transform.parent.Find("Model").transform.Find("VentGrate").gameObject.SetActive(false);
    }
		
	
}
