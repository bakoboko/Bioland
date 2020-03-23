using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour {

    private GameObject player;
    private ModuleManagementScript moduleManager;
    private PlayerCharacterScript pcScript;
    private EnemyBehaviour self;
    public static int attackTick = 0;
    public bool attackReset;
    
	
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        moduleManager = player.gameObject.GetComponent<ModuleManagementScript>();
        pcScript = player.gameObject.GetComponent<PlayerCharacterScript>();
        self = GetComponentInParent<EnemyBehaviour>();

	}
	
	void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            self.ChangeMaterial();
            if (self.attack == true)
            {
                if (moduleManager.armourBodyActive == true && pcScript.meleeDamageTick < PlayerCharacterScript.health)
                {
                    self.attack = false;
                    self.materialTick = 0;
                    attackTick++;
                    print("Block");
                }
                else
                {
                    pcScript.Death();
                }
            }
            else if(self.damageable == true)
            {
                if(moduleManager.strongArmsActive == true)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        self.KillSelf();
                    }
                }
            }
        }
    }

    void OnTriggerExit()
    {
        self.ResetMaterial();
    }

}
