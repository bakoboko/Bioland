using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertBoardScript : MonoBehaviour {

    private int buttonTick;
    private bool rocketButtonActive = false;
    private bool slActive = false;
    private bool ventButtonActive = false;
    private bool combatButtonActive = false;
    private bool stealthButtonActive = false;
    private bool disguiseButtonActive = false;

    public static bool openDoor = false;

    void Update()
    {
        AlertCheck();
        DoorOpen();
    }

    void AlertCheck()
    {
        if(ArmScript.rocketButton == true && rocketButtonActive == false)
        {
            buttonTick ++;
            print(buttonTick);
          //  ArmScript.rocketButton = false;
            rocketButtonActive = true;
        }
        if(strongLegsButton.strongLegsButtonActive == true && slActive == false)
        {
            buttonTick++;
            print(buttonTick);
            slActive = true;
        }

        if (VentButtonScript.ventButton == true && ventButtonActive == false)
        {
            buttonTick++;
            print(buttonTick);
            ventButtonActive = true;
        }

        if (CombatButtonScript.combatButton == true && combatButtonActive == false)
        {
            buttonTick++;
            print(buttonTick);
            combatButtonActive = true;
        }

        if (StealthButtonScript.stealthButton == true && stealthButtonActive == false)
        {
            buttonTick++;
            print(buttonTick);
            stealthButtonActive = true;
        }

        if (DisguiseButtonScript.disguiseButton == true && disguiseButtonActive == false)
        {
            buttonTick++;
            print(buttonTick);
            disguiseButtonActive = true;
        }
    }

    void DoorOpen()
    {
        if(buttonTick == 1)
        {
            GameObject.Find("light1").GetComponent<Renderer>().material.color = Color.green;
        }
        if (buttonTick == 2)
        {
            GameObject.Find("light2").GetComponent<Renderer>().material.color = Color.green;
        }
        if (buttonTick == 3)
        {
            GameObject.Find("light3").GetComponent<Renderer>().material.color = Color.green;
        }
        if (buttonTick == 4)
        {
            GameObject.Find("light4").GetComponent<Renderer>().material.color = Color.green;
        }
        if (buttonTick == 5)
        {
            GameObject.Find("light5").GetComponent<Renderer>().material.color = Color.green;
        }
        if (buttonTick == 6)
        {
            GameObject.Find("light6").GetComponent<Renderer>().material.color = Color.green;
        }

        if(buttonTick == 6)
        {
            openDoor = true;
        }
    }
}
