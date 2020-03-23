using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCharacterScript : MonoBehaviour {

    [SerializeField] private FPSView mouseLook;
    private CharacterController player;
    private ModuleManagementScript moduleManager;
    private ArmScript armScript;
    private GameObject arm;
    private GameObject pause;
    private GameObject deathMenu;
    
    private GameObject rocketArm;
    private GameObject armModel;
    private Camera fpsCamera;
    private Vector3 move = Vector3.zero;
    private Vector2 moveInput;
    private Vector2 look;
    private Texture2D crosshair;
    private Vector3 hitPos;
    private Vector3 deathRotation;
    private float distanceFromPlayer;
    private int jumpTick;
    private float fuel = 100;
    private float fuelDrain = 33;
    private bool cloneTick = false;
    private bool adjustAim = false;
    private float timeNow;
    private float bulletDropWaitTime = 0.7f;
    private float bulletDrop = -0.01f;
    private bool isFired = false;
    private bool letknow;
    private bool checkToContinue;
  
    private bool addedBody = false;
    private bool addedHead = false;
    

    public Rigidbody projectile;
    public float fallSpeedMax = -10;
    public float moveSpeed = 10f;
    public float fastLegsMoveSpeed = 15f;
    public float arielMoveSpeed = 10f;
    public float jumpForce = 0.5f;
    public float highJumpForce = 0.8f;
    public float gravity = 2f;
    public float playerHealth = 10;
    public bool dead = false;
    public bool fireArm = false;
    public bool alertArm;
    public int rangeDamageTick;
    public int meleeDamageTick;
    public float setDistance = 7f;
    public static bool isLookingAtButton;
    public static bool paused;
    public static bool deathMenuActive;
    public static GameObject moduleUI;
    public static int health = 0;
    public static int score = 0;
    public static bool freeMouse;

    void Start()
    {
        pause = GameObject.FindGameObjectWithTag("pauseMenu");
        deathMenu = GameObject.FindGameObjectWithTag("deathMenu");
        moduleUI = GameObject.FindGameObjectWithTag("ModuleUI");
        moduleUI.SetActive(false);
        deathMenu.SetActive(false);
        pause.SetActive(false);
        fpsCamera = Camera.main;
        mouseLook.Initialisation(transform, fpsCamera.transform);
        player = gameObject.GetComponent<CharacterController>();
        moduleManager = player.GetComponent<ModuleManagementScript>();
        arm = GameObject.FindGameObjectWithTag("Arm");
        armModel = ArmManager.rocketArm;
        projectile = armModel.gameObject.GetComponent<Rigidbody>();
        deathRotation.z = player.transform.rotation.z + 90;
    }


    void Update()
    {
        if (paused != true && deathMenuActive != true && moduleUI.activeInHierarchy != true )
        {
            Movement();
            Rotate();
            Fall();
            JetPack();
            WallClimb();
            RocketArm();
            AddArmour();
            Raycast();
        }
        Pause();
        ModuleUI();
    }

    void ModuleUI()
    {
        if(moduleUI.activeInHierarchy == true)
        {
            Time.timeScale = 0;
            mouseLook.SetCursorLock(false);
        }
        else
        {
            Time.timeScale = 1;
            mouseLook.SetCursorLock(true);
        }

        if(ButtonManager.isFinished == true)
        {
            mouseLook.SetCursorLock(false);
        }

    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = true;
            
        }

        if(paused == true)
        {
            pause.SetActive(true);
            Time.timeScale = 0;
            mouseLook.SetCursorLock(false);
        }
        else
        {
            pause.SetActive(false);
            if(deathMenuActive != true)
            {
                Time.timeScale = 1;
            }
          
            mouseLook.SetCursorLock(true);
        }

        if(deathMenuActive == true)
        {
            deathMenu.SetActive(true);
            mouseLook.SetCursorLock(false);
            Time.timeScale = 0;
        }
        if(freeMouse == true)
        {
            mouseLook.SetCursorLock(false);
        }
    }

    void Raycast()
    {
        RaycastHit hit;

        Ray ray = fpsCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.distance < setDistance)
            {
                if (hit.collider.gameObject.tag == ("buttonColor"))
                {
                    isLookingAtButton = true;
                }
                else
                {
                    isLookingAtButton = false;
                }
            }
        }
    }

    void AddArmour()
    {

        if (moduleManager.armourBodyActive == true && addedBody == false)
        {
            health += 2;
            addedBody = true;
        }
        if (moduleManager.armourHeadActive == true && addedHead == false)
        {
            health += 2;
            addedHead = true;
        }
        rangeDamageTick = RangedEnemyAttackScript.attackTick;
        meleeDamageTick = EnemyAttackScript.attackTick;
    }

    void Rotate()
    {
        mouseLook.LookRotation(transform, fpsCamera.transform);
    }

    void Movement()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveInput = new Vector2(horizontal, vertical);

        if(moveInput.sqrMagnitude > 1)
        {
            moveInput.Normalize();
        }

        Vector3 moveDirection = transform.forward * moveInput.y + transform.right * moveInput.x;

        move.x = moveDirection.x;
        move.z = moveDirection.z;

        if (player.isGrounded)
        {
            move.y = 0;
            jumpTick = 0;

            if(moduleManager.fastLegsActive == true)
            {
                move = move * fastLegsMoveSpeed * Time.deltaTime;
            }
            else
            {
                move = move * moveSpeed * Time.deltaTime;
            }
                    
        }
        else
        {
            if(moduleManager.fastLegsActive == true)
            {
                move.x = move.x * fastLegsMoveSpeed * Time.deltaTime;
                move.z = move.z * fastLegsMoveSpeed * Time.deltaTime;
            }
            else
            {
                move.x = move.x * arielMoveSpeed * Time.deltaTime;
                move.z = move.z * arielMoveSpeed * Time.deltaTime;
            }
           
            move.y -= gravity * Time.deltaTime;
          
        }


        if (Input.GetButtonDown("Jump"))
        {
                if (jumpTick == 0 && moduleManager.strongLegsActive == false)
                {
                    move.y = jumpForce;
                    jumpTick = 1;
                }
                else if (jumpTick == 0)
                {
                    move.y = highJumpForce;
                    jumpTick = 1;
                }
        }

        player.Move(move);
        mouseLook.UpdateCursorLock();
    }



    void JetPack()
    {   
        if (moduleManager.jetpackBodyActive == true)
        {
            if (player.isGrounded == false && jumpTick == 1)
            {
                if (Input.GetButton("Jump") && fuel > 1)
                {
                    move.y = move.y + 0.04f;
                    fuel = fuel - fuelDrain * Time.deltaTime;
                }
                if(player.velocity.y > 20f)
                {
                    move.y = move.y - 0.04f;
                }
            }
            else if(player.isGrounded)
            {
                fuel = 100;
            }
        }
    }

    
    void Fall()
    { 
        if(player.velocity.y < fallSpeedMax && moduleManager.strongLegsActive == false)
        {
            Death();
        }
    }

    public void Death()
    {
        
        if (paused != true && deathMenuActive != true && moduleUI.activeInHierarchy != true)
        {
            transform.Rotate(deathRotation);
            deathMenuActive = true;
        }
  

    }

    void WallClimb()
    {
        if(ClimbWall.isClimbing == true)
        {
            move.x = 0;
            move.y = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        }
    }

    public void Bounce()
    {
        float bounceForce = jumpForce / 1.3f;
        move.y = bounceForce;
        player.Move(move);
    }

    void OnGUI()
    {
        if(paused != true && deathMenuActive != true && moduleUI.activeInHierarchy != true)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 5, 5), "");
        }
        
    }

    void TimeUpdate()
    {
        timeNow = Time.time + bulletDropWaitTime;
    }

    void RocketArm()
    {
        if (moduleManager.rocketArmsActive == true)
        {
            Vector3 newpos = arm.transform.position;
            

            if (Input.GetButtonDown("Fire1"))
            {
                if (isFired == false)
                {
                    TimeUpdate();
                    if (fpsCamera.transform.rotation.x < -0.35)
                    {
                        print("You Can't Shoot Here");
                    }
                    else if (fpsCamera.transform.rotation.x > 0.3)
                    {
                        print("You Can't Shoot Here");
                    }
                    else
                    {
                        fireArm = true;
                    }
                }
                else
                {
                    print("I need to get my arm back!");
                }
            }


            if (cloneTick == false && fireArm == true)
            {
                projectile.gameObject.SetActive(false);
                Rigidbody clone;
                clone = Instantiate(projectile, newpos, projectile.transform.rotation) as Rigidbody;
                clone.gameObject.SetActive(true);
                rocketArm = clone.gameObject;
                cloneTick = true;
                adjustAim = true;
            }
            else if(cloneTick == false)
            {
                projectile.gameObject.SetActive(true);
            }


            if (adjustAim == true)
            {
                rocketArm.transform.localRotation = fpsCamera.transform.rotation;
                rocketArm.transform.Rotate(Vector3.up, -90);
                adjustAim = false;
            }
            
            if (fireArm == true && cloneTick == true)
            {
                armScript = rocketArm.GetComponent<ArmScript>();
                
                isFired = true;

                if (Time.time < timeNow)
                {
                    rocketArm.GetComponentInChildren<Collider>().enabled = true;
                    rocketArm.GetComponent<Rigidbody>().isKinematic = false;
                    rocketArm.transform.Translate(Vector3.right / 5);
                }
                else if (Time.time < timeNow + 2f)
                {
                    rocketArm.transform.Translate(Vector3.right / 5);
                    rocketArm.transform.Translate(0, bulletDrop, 0);
                }
                else
                {
                    alertArm = true;     
                }
                if (armScript.drop == true)
                {
                    fireArm = false;
                    alertArm = false;
                }
                
            }


            if (cloneTick == true)
            {
                Vector3 rocketArmnew = GameObject.FindGameObjectWithTag("rocketArm").transform.position;
                distanceFromPlayer = Vector3.Distance(rocketArmnew, player.transform.position);
            }

            if (distanceFromPlayer <= 4 && cloneTick == true)
            {
                print("Press E to PickUp");
                if (Input.GetKey(KeyCode.E))
                {
                    Destroy(rocketArm);
                    projectile.gameObject.SetActive(true);
                    isFired = false;
                    cloneTick = false;
                }
            }
        }
        else
        {
            projectile.gameObject.SetActive(false);
        }

    }
  
}
    

