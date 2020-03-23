using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleManagementScript : MonoBehaviour {
    private GameObject ventArm;
    private GameObject climbArm;
    private GameObject strongArm;


    //HeadVariables
    public bool armourHead;
    public bool disguiseHead;
    public bool detectionHead;
    //BodyVariables
    public bool armourBody;
    public bool jetpackBody;
    public bool stealthBody;
    //ArmVariables
    public bool climbArms;
    public bool ventArms;
    public bool strongArms;
    public bool rocketArms;
    //LegVariables
    public bool fastLegs;
    public bool spikeLegs;
    public bool strongLegs;

    public bool armourHeadActive;
    public bool disguiseHeadActive;
    public bool detectionHeadActive;

    public bool armourBodyActive;
    public bool jetpackBodyActive;
    public bool stealthBodyActive;

    public bool climbArmsActive;
    public bool ventArmsActive;
    public bool strongArmsActive;
    public bool rocketArmsActive;

    public bool fastLegsActive;
    public bool spikeLegsActive;
    public bool strongLegsActive;


    void Start ()
    {
         ModuleReset();
        ventArm = GameObject.FindGameObjectWithTag("ventArmModel");
        climbArm = GameObject.FindGameObjectWithTag("climbArmModel");
        strongArm = GameObject.FindGameObjectWithTag("strongArmModel");

        ventArm.SetActive(false);
        climbArm.SetActive(false);
        strongArm.SetActive(false);
    }
	
	
	void Update ()
    {
        ModuleManagement();
	}

    public void ModuleManagement()
    {

        if (armourHead == true)
        {
            armourHeadActive = true;
        }
        else
        {
            armourHeadActive = false;
        }

        if (disguiseHead == true)
        {
            disguiseHeadActive = true;
        }
        else
        {
            disguiseHeadActive = false;
        }

        if (detectionHead == true)
        {
            detectionHeadActive = true;
        }
        else
        {
            detectionHeadActive = false;
        }

        if (armourBody == true)
        {
            armourBodyActive = true;
        }
        else
        {
            armourBodyActive = false;
        }

        if (jetpackBody == true)
        {
            jetpackBodyActive = true;
        }
        else
        {
            jetpackBodyActive = false;
        }


        if (stealthBody == true)
        {
            stealthBodyActive = true;
        }
        else
        {
            stealthBodyActive = false;
        }


        if (climbArms == true)
        {
            climbArmsActive = true;
            climbArm.SetActive(true);
        }
        else
        {
            climbArmsActive = false;
            climbArm.SetActive(false);
        }


        if (ventArms == true)
        {
            ventArmsActive = true;
            ventArm.SetActive(true);
        }
        else
        {
            ventArmsActive = false;
            ventArm.SetActive(false);
        }
 

        if (strongArms == true)
        {
            strongArmsActive = true;
            strongArm.SetActive(true);
        }
        else
        {
            strongArmsActive = false;
            strongArm.SetActive(false);
        }


        if (rocketArms == true)
        {
            rocketArmsActive = true;
        }
        else
        {
            rocketArmsActive = false;
        }


        if (fastLegs == true)
        {
            fastLegsActive = true;
        }
        else
        {
            fastLegsActive = false;
        }


        if (spikeLegs == true)
        {
            spikeLegsActive = true;
        }
        else
        {
            spikeLegsActive = false;
        }
            

        if (strongLegs == true)
        {
            strongLegsActive = true;
        }
        else
        {
            strongLegsActive = false;
        }

    }


    public void ModuleReset()
    {
        armourHead = false;
        disguiseHead = false;
        detectionHead = false;
        armourBody = false;
        jetpackBody = false;
        stealthBody = false;
        climbArms = false;
        ventArms = false;
        strongArms = false;
        rocketArms = false;
        fastLegs = false;
        spikeLegs = false;
        strongLegs = false;
    }
}
