using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorusScale : MonoBehaviour {
    private GameObject player;
    private PlayerCharacterScript pcScript;

    public float timeUntilDestroyed = 4.0f;
    public Vector3 scaleFactor = new Vector3(0.1f, 0.1f, 0.1f);

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pcScript = player.GetComponent<PlayerCharacterScript>();
    }

	void Awake () {
        StartCoroutine(DestroyInstance());
        gameObject.transform.SetParent(null);
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale += scaleFactor * Time.deltaTime /3;
	}

    IEnumerator DestroyInstance()
    {
        yield return new WaitForSeconds(timeUntilDestroyed);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Player"))
        {
            pcScript.Death();
        }
    
    }


}
