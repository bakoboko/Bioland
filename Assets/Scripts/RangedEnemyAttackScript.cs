using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttackScript : MonoBehaviour {

    private GameObject player;
    private ModuleManagementScript moduleManager;
    private PlayerCharacterScript pcScript;
    private RangedEnemyBehaviour self;
    public static int attackTick = 0;


    public bool attackReset;
    


    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        moduleManager = player.gameObject.GetComponent<ModuleManagementScript>();
        pcScript = player.gameObject.GetComponent<PlayerCharacterScript>();
        self = GetComponentInParent<RangedEnemyBehaviour>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            self.ChangeMaterial();
            if (RangedEnemyBehaviour.attack == true)
            {
                
                if (moduleManager.armourHeadActive == true && pcScript.rangeDamageTick < PlayerCharacterScript.health)
                {
                    RangedEnemyBehaviour.attack = false;
                    RangedEnemyBehaviour.materialTick = 0;
                    attackTick++;
                    print("Block");
                }
                else
                {
                    pcScript.Death();
                }
            }
        }
    }

}
