using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
    private GameObject levelSelector;
    private GameObject player;
    private GameObject startMenu;
    private GameObject scoreCard;
    private GameObject moduleUI;
    private bool hasLoaded;
    private ModuleManagementScript moduleManager;
    private int headButtonClicked = 0;
    private int bodyButtonClicked = 0;
    private int armsButtonClicked = 0;
    private int legsButtonClicked = 0;

    public static bool isFinished = false;

    void Start()
    {
        levelSelector = GameObject.FindGameObjectWithTag("levelSelector");
        startMenu = GameObject.FindGameObjectWithTag("startMenu");
        scoreCard = GameObject.FindGameObjectWithTag("scoreCard");
        moduleUI = GameObject.FindGameObjectWithTag("ModuleUI");
        player = GameObject.FindGameObjectWithTag("Player");
        
        
        if(SceneManager.GetActiveScene().buildIndex == 0 )
        {
            levelSelector.SetActive(false);
            if(isFinished != true)
            {
                scoreCard.SetActive(false);
            }
        }
        else
        {
            moduleManager = player.GetComponent<ModuleManagementScript>();
        }
   
    }

    void Update()
    {
        if (isFinished == true)
        {
            if(hasLoaded == false)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
                PlayerCharacterScript.score = PlayerCharacterScript.score + 100;

                hasLoaded = true;
            }
           
            scoreCard.SetActive(true);
            levelSelector.SetActive(false);
            startMenu.SetActive(false);
            Destroy(player);
        }
    }

    public void BuildClick()
    {
        moduleManager.ModuleReset();

        PCScript.menuOpen = false;
        if(PlayerCharacterScript.moduleUI.activeInHierarchy == true)
        {
            PlayerCharacterScript.moduleUI.SetActive(false);
        }
  
        if(headButtonClicked == 1)
        {
            moduleManager.armourHead = true;
            headButtonClicked = 0;
        }
        if (headButtonClicked == 2)
        {
            moduleManager.disguiseHead = true;
            headButtonClicked = 0;
        }
        if (headButtonClicked == 3)
        {
            moduleManager.detectionHead = true;
            headButtonClicked = 0;
        }

        if (bodyButtonClicked == 1)
        {
            moduleManager.armourBody = true;
            bodyButtonClicked = 0;
        }

        if (bodyButtonClicked == 2)
        {
            moduleManager.jetpackBody = true;
            bodyButtonClicked = 0;
        }

        if (bodyButtonClicked == 3)
        {
            moduleManager.stealthBody = true;
            bodyButtonClicked = 0;
        }

        if (armsButtonClicked == 1)
        {
            moduleManager.climbArms = true;
            armsButtonClicked = 0;
        }

        if (armsButtonClicked == 2)
        {
            moduleManager.ventArms = true;
            armsButtonClicked = 0;
        }


        if (armsButtonClicked == 3)
        {
            moduleManager.strongArms = true;
            armsButtonClicked = 0;
        }


        if (armsButtonClicked == 4)
        {
            moduleManager.rocketArms = true;
            armsButtonClicked = 0;
        }

        if (legsButtonClicked == 1)
        {
            moduleManager.fastLegs = true;
            legsButtonClicked = 0;
        }

        if (legsButtonClicked == 2)
        {
            moduleManager.spikeLegs = true;
            legsButtonClicked = 0;
        }

        if (legsButtonClicked == 3)
        {
            moduleManager.strongLegs = true;
            legsButtonClicked = 0;
        }
    }

    public void StartClick()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerCharacterScript.freeMouse = false;
    }

    public void MainGameLevelClick()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 2);
        PlayerCharacterScript.freeMouse = false;
    }

    public void BossFightClick()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 3);
        PlayerCharacterScript.freeMouse = false;
    }

    public void LevelManagerClick()
    {
       
        levelSelector.SetActive(true);
        startMenu.SetActive(false);
    }

    public void ExitGameClick()
    {
            Application.Quit();     
    }


    public void ContinueClick()
    {
        PlayerCharacterScript.paused = false;
        PCScript.menuOpen = false;
        if (PlayerCharacterScript.moduleUI.activeInHierarchy)
        {
            PlayerCharacterScript.moduleUI.SetActive(false);
            headButtonClicked = 0;
            bodyButtonClicked = 0;
            legsButtonClicked = 0;
            armsButtonClicked = 0;
        }
      
    }

    public void MainMenuClick()
    {
        levelSelector.SetActive(false);
        startMenu.SetActive(true);
        scoreCard.SetActive(false);
        isFinished = false;
    }

    public void RebuildClick()
    {
        player.GetComponent<ModuleManagementScript>().ModuleReset();
        PlayerCharacterScript.paused = false;
        
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        PlayerCharacterScript.deathMenuActive = false;
    }

    public void ExitClick()
    {
        PlayerCharacterScript.paused = false;
        PlayerCharacterScript.deathMenuActive = false;
        PlayerCharacterScript.freeMouse = true;
        SceneManager.LoadScene(0);
    }

    public void headOneClick()
    {
        headButtonClicked = 1;
    }


    public void headTwoClick()
    {
        headButtonClicked = 2;
    }


    public void headThreeClick()
    {
        headButtonClicked = 3;
    }


    public void bodyOneClick()
    {
        bodyButtonClicked = 1;
    }

    public void bodyTwoClick()
    {
        bodyButtonClicked = 2;
    }

    public void bodyThreeClick()
    {
        bodyButtonClicked = 3;
    }

    public void armsOneClick()
    {
        armsButtonClicked = 1;
    }

    public void armsTwoClick()
    {
        armsButtonClicked = 2;
    }

    public void armsThreeClick()
    {
        armsButtonClicked = 3;
    }

    public void armsFourClick()
    {
        armsButtonClicked = 4;
    }

    public void legsOneClick()
    {
        legsButtonClicked = 1;
    }

    public void legsTwoClick()
    {
        legsButtonClicked = 2;
    }

    public void legsThreeClick()
    {
        legsButtonClicked = 3;
    }

}
