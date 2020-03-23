using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmManager : MonoBehaviour {
    private GameObject player;
    public static GameObject rocketArm;
    private ModuleManagementScript moduleManager;
    private bool hasArmSetActive = false;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        moduleManager = player.GetComponent<ModuleManagementScript>();
        ArmInitialisation();
    }
	

	void Update ()
    {
        Manager();
	}

    void Manager()
    {
        if(moduleManager.rocketArmsActive == true && hasArmSetActive == false)
        {
            rocketArm.SetActive(true);
            hasArmSetActive = true;
        }
        else if(hasArmSetActive == false)
        {
            rocketArm.SetActive(false);
            hasArmSetActive = true;
        }
    }

    void ArmInitialisation()
    {
        rocketArm = GameObject.Find("RocketArmModel");
        rocketArm.SetActive(false);
    }
}
