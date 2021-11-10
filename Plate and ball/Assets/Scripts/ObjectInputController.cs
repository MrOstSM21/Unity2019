using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInputController
{
    private float moveHorizontal= Input.GetAxis("Horizontal");
    private bool startBallMovement;

    public float HorizontalDisplacementInput()
    {
        return moveHorizontal;
    }

    public bool StartBallMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startBallMovement = true;
        }
        return startBallMovement;
        
    }

}
