using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbWall : MonoBehaviour {
    private CharacterController player;
    private ModuleManagementScript moduleManager;
    private PlayerCharacterScript pcScript;

    public static bool isClimbing;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        moduleManager = player.GetComponent<ModuleManagementScript>();
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && moduleManager.climbArmsActive == true)
        {
            isClimbing = true;
        }
    }

    void OnTriggerExit()
    {
        isClimbing = false;
    }
}
