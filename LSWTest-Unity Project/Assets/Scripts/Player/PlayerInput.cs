using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*This class is in charge of handling the player's input, having it separated makes it easier to debug and understand it,
 it is also safer in the event that you want to adapt it for a multiplayer game ModelViewController*/
public class PlayerInput : MonoBehaviour
{
    [Header("Player input parameters")]
    public bool blockInput = false;
    public bool interact;
    public Vector2 movement;
    private void OnEnable()
    {
        EventManager.Subscribe(Constantes.TogglePlayerInput, ToggleInput);
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe(Constantes.TogglePlayerInput, ToggleInput);
    }

    private void ToggleInput(params object[] x)
    {
        if (!(x[0] is TogglePlayerInputDP)) return;
        var dp = (TogglePlayerInputDP)x[0];

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

    private void ResetInput()
    {
        movement.x = 0;
        movement.y = 0;
    }
}


