using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyDamageScript : MonoBehaviour {

    private GameObject player;
    private ModuleManagementScript moduleManager;
    private PlayerCharacterScript pcScript;
    private RangedEnemyBehaviour enemyScript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moduleManager = player.gameObject.GetComponent<ModuleManagementScript>();
        enemyScript = gameObject.GetComponentInParent<RangedEnemyBehaviour>();
        pcScript = player.gameObject.GetComponent<PlayerCharacterScript>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (moduleManager.spikeLegsActive == true)
            {
                enemyScript.KillSelf();
                pcScript.Bounce();
            }
        }
    }

}
