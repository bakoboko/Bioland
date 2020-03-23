using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour {

    public Rigidbody bulletPrefab;
    public GameObject playerChar;
    public float speed = 10;
    public float shootrate = 1;
    private float timer;
	// Use this for initialization
	void Start () {
        timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        //gameObject.transform.LookAt(playerChar.transform);
        if (timer < Time.time)
        {
            Rigidbody bulletInst = Instantiate(bulletPrefab, gameObject.transform);
            bulletInst.transform.LookAt(playerChar.transform);
            bulletInst.transform.Translate(Vector3.forward / 10);
            timer = Time.time + shootrate;
        }
	}
}
