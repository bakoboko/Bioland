using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyDetectionScript : MonoBehaviour {


    private GameObject player;
    private ModuleManagementScript moduleManager;
    private float detectionRoll;
    private bool hasDetected;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moduleManager = player.GetComponent<ModuleManagementScript>();
        hasDetected = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (hasDetected == true)
            {
                hasDetected = false;
            }
        }
    }



    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (moduleManager.stealthBodyActive == true && hasDetected == false)
            {
                DetectionCalculator();
            }
            else if (moduleManager.stealthBodyActive == false)
            {
                Detection();
            }
        }
    }


    void DetectionCalculator()
    {
        hasDetected = true;
        detectionRoll = Random.Range(0f, 10f);

        if (detectionRoll > 5f)
        {
            print("Stealth Failed");
            Detection();
        }
        else
        {
            print("Stealth Success");
        }
    }


    void Detection()
    {
        transform.parent.gameObject.GetComponent<RangedEnemyBehaviour>().ActiveState();
    }

    void OnTriggerExit()
    {
        transform.parent.gameObject.GetComponent<RangedEnemyBehaviour>().ResetMaterial();
    }


}
