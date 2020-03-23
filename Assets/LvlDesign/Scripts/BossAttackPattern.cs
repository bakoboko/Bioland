using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackPattern : MonoBehaviour {

    [SerializeField] private DamageToBoss bossAttacked;
    [SerializeField] private Transform[] stompWaypoint;
    [SerializeField] private Transform[] shootWaypoint;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(bossAttacked.moveAfterHit == false)
        {
            

            if(DamageToBoss.hitCount >= 3)
            {
                Laser();
            }
        }
	}


    private void Stomp()
    {
        //area in all directions from position of the boss
    }

    private void MachineShoot()
    {
        //at player or in lines
    }

    private void Laser()
    {
        //raycast then shoot, always hit
    }

    //Stomp
    //Shooting from point to point
    //rest - player attack

    //boss runs back

    //Stomp
    //Shooting from point to point
    //rest - player attack

    //boss runs back

    //Stomp
    //Shooting from point to point
    //rest - player attack
    //Laser

    //boss runs back - win
}
