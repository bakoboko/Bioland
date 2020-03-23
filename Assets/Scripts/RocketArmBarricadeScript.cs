using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketArmBarricadeScript : MonoBehaviour {
    private bool moveDown = false;
    public static bool hasMoved = false;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }


	void Update ()
    {
        MoveDown();
	}

    void MoveDown()
    {
        if (ArmScript.rocketButton == true)
        {
            moveDown = true;
        }

        if (moveDown == true && hasMoved == false)
        {
            transform.Translate(Vector3.down / 10);
            if(transform.position.y < startPos.y - 2.5)
            {
                moveDown = false;
                hasMoved = true;
            }
        }
    }
}
