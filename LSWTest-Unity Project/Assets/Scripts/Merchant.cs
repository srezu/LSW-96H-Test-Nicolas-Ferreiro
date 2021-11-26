using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/*Class that unifies the things of the merchant such as their interaction and inventory management*/
public class Merchant : MonoBehaviour, IInteractive
{
    public UnityEvent Interact;
    public UnityEvent ExitInteract;

    public bool inInteract;

    public void OnInteract()
    { 
        if (inInteract) return;
        
       inInteract = true;
       Interact.Invoke();
       EventManager.Call(Constantes.ToggleInventory, new ToggleInventoryDP() { toggle = true});
    }
    
    public void OnExitInteract()
    {
        inInteract = false;
        ExitInteract.Invoke();
    }
}
