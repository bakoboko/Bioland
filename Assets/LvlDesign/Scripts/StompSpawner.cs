using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompSpawner : MonoBehaviour {

    [SerializeField] private float interval = 3.0f;
    [SerializeField] private GameObject stompPrefab;


    public static bool keepStomping;
    // Use this for initialization
    void Start () {
        keepStomping = true;
        StartCoroutine(StompSpawnInterval());
	}
	
	// Update is called once per frame
	void Update() { 
	}

    IEnumerator StompSpawnInterval()
    {
        while(keepStomping == true)
        {
            Instantiate(stompPrefab, gameObject.transform);
            yield return new WaitForSeconds(interval);
        }
    }


}
