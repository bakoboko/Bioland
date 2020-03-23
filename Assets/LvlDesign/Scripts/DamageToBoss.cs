using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToBoss : MonoBehaviour {

    [SerializeField] private Transform[] newPosition;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private GameObject stompSpawner;
    private bool winTick = false;
    private GameObject chest;
    public bool moveAfterHit = false;
    public static int hitCount;
	// Use this for initialization
	void Start () {
        hitCount = 0;
        chest = GameObject.FindGameObjectWithTag("chest");
        chest.SetActive(false);
        stompSpawner.GetComponent<StompSpawner>().enabled = false;
        StompSpawner.keepStomping = false;
    }
	

	void Update ()
    {
        StartFight();
        BossMove();
    }

    void StartFight()
    {
        if(StartBossScript.bossStart == true)
        {
            stompSpawner.GetComponent<StompSpawner>().enabled = true;
            StompSpawner.keepStomping = true;
            StartBossScript.bossStart = false;
        }
    }

    void BossMove()
    {
        if (moveAfterHit == true)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, newPosition[hitCount].position, speed);

            if (Vector3.Distance(gameObject.transform.position, newPosition[hitCount].position) < 0.1f)
            {
                moveAfterHit = false;
                hitCount++;

                if (hitCount >= 4)
                {
                    GameWon();
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ArmModel")
        {
            moveAfterHit = true;
        }
    }

    private void GameWon()
    {
        stompSpawner.GetComponent<StompSpawner>().enabled = false;
        StompSpawner.keepStomping = false;
        chest.SetActive(true);

    }
}
