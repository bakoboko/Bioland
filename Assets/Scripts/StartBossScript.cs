using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBossScript : MonoBehaviour {

    public static bool bossStart = false;

	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            bossStart = true;
        }
    }
}
