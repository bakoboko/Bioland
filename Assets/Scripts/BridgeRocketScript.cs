using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeRocketScript : MonoBehaviour {
    private GameObject bridge;
    private bool moveBridge;
    private Vector3 startPos;
    private bool hasMoved = false;
    private bool activateBridge = false;

    void Start()
    {
        bridge = GameObject.FindGameObjectWithTag("bridge");
        startPos = bridge.transform.position;
        bridge.SetActive(false);
    }

	void Update()
    {
        if(ArmScript.rocketButtonBridge == true)
        {
            transform.Find("ButtonColorBridge").gameObject.GetComponent<Renderer>().material.color = Color.green;
            moveBridge = true;
            activateBridge = true;
           
        }

        if(activateBridge == true)
        {
            bridge.SetActive(true);
        }

        if(moveBridge == true && hasMoved == false)
        {
            
            bridge.transform.Translate(Vector3.back / 10);
            if(bridge.transform.position.z < startPos.z - 6)
            {
                hasMoved = true;
            }
            
        }
    }
}
