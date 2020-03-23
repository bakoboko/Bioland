using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour {


    public float timeUntilDestroyed = 2.0f;
    // Use this for initialization
    void Awake()
    {
        StartCoroutine(DestroyInstance());
    }

    // Update is called once per frame
    void Update () {
		
	}

    IEnumerator DestroyInstance()
    {
        yield return new WaitForSeconds(timeUntilDestroyed);
        Destroy(gameObject);
    }
}
