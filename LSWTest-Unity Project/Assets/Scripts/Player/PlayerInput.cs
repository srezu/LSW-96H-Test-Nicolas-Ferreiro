using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool blockInput = false;
    public Vector2 movement;
    public bool interact;
    private void OnEnable()
    {
        EventManager.Subscribe(Constantes.TogglePlayerInput, ToggleInput);
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe(Constantes.TogglePlayerInput, ToggleInput);
    }
    
    public void ToggleInput(params object[] x)
    {
        if (!(x[0] is TogglePlayerInputDP)) return;
        TogglePlayerInputDP dp = (TogglePlayerInputDP)x[0];

        blockInput = dp.toggle;
        ResetInput();
    }

    public void Update()
    {
        if (blockInput) return;
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        interact = Input.GetButtonDown("Interact");

    }

    public void ResetInput()
    {
        movement.x = 0;
        movement.y = 0;
    }
}

