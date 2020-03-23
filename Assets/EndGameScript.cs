using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour {
    private bool winTick = false;

	
	void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(DamageToBoss.hitCount >= 4)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    if (winTick == false)
                    {
                        ButtonManager.isFinished = true;
                        winTick = true;
                    }
                }
            }
        }
    }
}
