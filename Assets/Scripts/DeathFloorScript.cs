using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFloorScript : MonoBehaviour {
    private GameObject player;
    private PlayerCharacterScript pcScript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Player"))
        {
            player.GetComponent<PlayerCharacterScript>().Death();
        }
    }
}
