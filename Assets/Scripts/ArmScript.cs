using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmScript : MonoBehaviour
{
    private GameObject player;
    private PlayerCharacterScript pcScript;
    private Renderer[] rend;

    public bool drop;
    public bool checkContinue;
    public static bool rocketButton;
    public static bool rocketButtonBridge;

    void Start()
    {
        rend = GetComponentsInChildren<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        pcScript = player.gameObject.GetComponent<PlayerCharacterScript>();
        drop = false;
    }

    void Update()
    {
        if (pcScript.alertArm == true)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            checkContinue = true;
            drop = true;

            foreach (Renderer material in rend)
            {
                material.material.color = Color.green;

            }
            
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == ("Enemy") || other.gameObject.tag == ("RangedEnemy"))
        {
            drop = true;
            foreach(Renderer material in rend)
            {
                material.material.color = Color.green;
            }
          
            GameObject enemy = other.transform.gameObject;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            PlayerCharacterScript.score++;
            Destroy(enemy);
        }

        else if (other.gameObject.tag != ("Player"))
        {
            drop = true;
            foreach (Renderer material in rend)
            {
                material.material.color = Color.green;
            }
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }

        if(other.gameObject.tag == ("rocketButton"))
        {
          
                rocketButton = true;
        }
        if (other.gameObject.tag == ("rocketButtonBridge"))
        {

            rocketButtonBridge = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag != ("Player"))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            
        }
    }
}


