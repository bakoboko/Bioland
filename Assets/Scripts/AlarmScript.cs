using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmScript : MonoBehaviour {

    private GameObject player;
    private GameObject enemy;
    private EnemyBehaviour enemyScript;
    private ModuleManagementScript moduleManager;
    private float detectionRoll;
    private bool hasDetected;

    public static bool alarmAlert;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moduleManager = player.GetComponent<ModuleManagementScript>();
        hasDetected = false;
        alarmAlert = false;
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
       alarmAlert = true;
    }
}
