using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool blockInput = false;
    


    public Vector2 movement;

    public void Update()
    {
        if (blockInput) return;
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        /*
        if (Input.GetAxisRaw("Vertical") == 0)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = 0;
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            movement.x = 0;
            movement.y = Input.GetAxisRaw("Vertical");
        }*/
    }
}


