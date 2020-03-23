using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{

	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Player"))
        {
            print("wow");
            if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
                AlarmScript.alarmAlert = false;
            }
        }
    }
 
}
