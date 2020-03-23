using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyBehaviour : MonoBehaviour {
    private GameObject player;
    private GameObject enemy;
    private Renderer[] sight;
    private GameObject[] mark;
    private Renderer[] rend;
    private Renderer vision;
    private EnemyBehaviour enemyScript;
    private Vector3 target = Vector3.zero;

    private int detect;
    private float distance;
    private float distanceFromTarget;
    private float attackWaitTime = 0.8f;
    private float attackTimeNow;

    public static int materialTick = 0;
    public static float timeNow;
    public static bool alert;
    public static float waitTime = 5f;
    public static bool attack;
    public bool damageable;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        mark = GameObject.FindGameObjectsWithTag("rangedAlert");
        enemyScript = enemy.GetComponent<EnemyBehaviour>();
        alert = false;
    }



    void Update()
    {
        Alert();
    }

    public void Look()
    {
        TimeUpdate();

        target = player.transform.position;
        target.y = transform.position.y;

        transform.LookAt(target);

        if (alert == false)
        {
            alert = true;
        }
    }


    void TimeUpdate()
    {
        timeNow = Time.time + waitTime;
    }


    public void Alert()
    {
        target = player.transform.position;
        target.y = player.transform.position.y + 3f;

        if (alert == true)
        {
           // enemyScript.Alert();

            foreach (GameObject wow in mark)
            {
                wow.GetComponent<MeshRenderer>().enabled = true;
            }

            if (Time.time < timeNow)
            {
                transform.LookAt(target);
            }
            else
            {
                alert = false;
            }
        }
        else
        {
            foreach (GameObject wow in mark)
            {
                wow.GetComponent<MeshRenderer>().enabled = false;
            }
           // transform.GetComponent<Rigidbody>().MoveRotation(startRotation);
        }
    }

    public void ActiveState()
    {
        Alert();
        Look();
        ChangeMaterial();
    }



    public void KillSelf()
    {
        Destroy(gameObject);
    }

    public void ChangeMaterial()
    {
        rend = transform.Find("Model").gameObject.GetComponentsInChildren<Renderer>();
        vision = transform.Find("LineOfSight").gameObject.GetComponentInChildren<Renderer>();
    
        if (materialTick == 0)
        {
            vision.material.color = Color.yellow;
            foreach (Renderer material in rend)
            {
                material.material.color = Color.yellow;
                materialTick = 1;
                attackTimeNow = Time.time + attackWaitTime;
            }
        }

        if (Time.time > attackTimeNow && materialTick == 1)
        {
            vision.material.color = Color.red;
            foreach (Renderer material in rend)
            {
                material.material.color = Color.red;
                materialTick = 2;
                attack = true;
            }

        }
    }

    public void ResetMaterial()
    {
        vision.material.color = Color.green;

        foreach (Renderer material in rend)
        {
            material.material.color = Color.white;
        }
        materialTick = 0;
    }
}

