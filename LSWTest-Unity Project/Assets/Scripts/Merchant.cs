using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Merchant : MonoBehaviour, IInteractive
{



    public UnityEvent Interact;
    public UnityEvent ExitInteract;


    public void OnInteract()
    {
       Interact.Invoke();
       EventManager.Call(Constantes.ToggleInventory, new ToggleInventoryDP() { toggle = true});

    }
    
    public void OnExitInteract()
    {
        ExitInteract.Invoke();

    }
}
