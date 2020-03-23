using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
    private GameObject player;
    private GameObject[] cones;
    private GameObject[] mark;
    private Renderer[] sight;
    private Renderer[] materials;
    private ModuleManagementScript moduleManager;
    private EnemyAttackScript enemy;
    private Vector3 target = Vector3.zero;
    private Vector3 startPosition = Vector3.zero;
    private Quaternion startRotation;
    
    private int detect;
    private float distance;
    private float distanceFromTarget;
    private float attackWaitTime = 0.8f;
    private float attackTimeNow;
    private bool hasLooked = true;
    
    public static float timeNow;
    public static bool alert;
    public static float waitTime = 5f;
    public int materialTick = 0;
    public bool attack;
    public bool damageable;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moduleManager = player.gameObject.GetComponent<ModuleManagementScript>();
        mark = GameObject.FindGameObjectsWithTag("meleeAlert");
        GetComponent<EnemyAttackScript>();

        SetPosAndRot();
    }

    void SetPosAndRot()
    {
        startPosition = transform.position;
        startRotation = transform.GetComponent<Rigidbody>().rotation;
    }


    void Update()
    {
        Alert();
        ConeVisible();
        PassiveState();
        CheckForAlarm();
    }

    void CheckForAlarm()
    {
        if(AlarmScript.alarmAlert == true)
        {
            ActiveState();
        }
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


    void Move()
    {
        distanceFromTarget = Vector3.Distance(transform.position, target);
        transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        hasLooked = false;

        if (distanceFromTarget > 3)
        {
            transform.Translate(Vector3.forward / 20);
        }
    }


    void TimeUpdate()
    {
        timeNow = Time.time + waitTime;
    }


    public void Alert()
    {
        

        target = player.transform.position;
        target.y = transform.position.y;

        if (alert == true)
        {
            transform.LookAt(target);
               

            foreach (GameObject wow in mark)
            {
                wow.GetComponent<MeshRenderer>().enabled = true;
            }

            if (Time.time < timeNow)
            {
                Move();
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
        }
    }

    void ConeVisible()
    {
        cones = GameObject.FindGameObjectsWithTag("Cone");

        if (moduleManager.detectionHeadActive == true)
        {
            for (int i = 0; i < cones.Length; i++)
                cones[i].gameObject.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            for (int i = 0; i < cones.Length; i++)
                cones[i].gameObject.GetComponent<Renderer>().enabled = false;

        }
    }

    public void ActiveState()
    {
        Look();
        Move();
    }

    void PassiveState()
    {
        distance = Vector3.Distance(transform.position, startPosition);

        if (alert == false && distance > 1)
        {
            transform.LookAt(startPosition);
            transform.Translate(Vector3.forward / 10);
        }
        else if (distance < 1)
        {
            if (hasLooked == false)
            {
                transform.GetComponent<Rigidbody>().isKinematic = true;
                transform.GetComponent<Rigidbody>().rotation = startRotation;
                hasLooked = true;
            }
        }
       
    }

    public void KillSelf()
    {
        PlayerCharacterScript.score = PlayerCharacterScript.score + 1;
        Destroy(gameObject);
    }

    public void ChangeMaterial()
    {
        materials = transform.Find("Model").GetComponentsInChildren<Renderer>();

        if (materialTick == 0)
        {
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i].material.color = Color.yellow;
                materialTick = 1;
                attackTimeNow = Time.time + attackWaitTime;
                damageable = true;
            }
        }
        if (Time.time > attackTimeNow && materialTick == 1)
        {
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i].material.color = Color.red;
                attack = true;
                damageable = false;
            }
        }
    }

    public void ResetMaterial()
    {
        materials = transform.Find("Model").GetComponentsInChildren<Renderer>();

        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].material.color = Color.white;
            materialTick = 0;
            attack = false;
            damageable = false;
        }
    }
}
