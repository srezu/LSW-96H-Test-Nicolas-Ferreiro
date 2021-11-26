using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;


/*This class is in charge of detecting if there is an interactive object near the player.
 If there is, the player can interact with that object using its interface*/
public class PlayerInteraction : MonoBehaviour
{
    public GameObject interactKeyHUD;
    private PlayerInput _playerInput;
    private IInteractive _focusObject;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if(_playerInput.interact) Interact();
    }

    private void Interact()
    {
        if(_focusObject != null) _focusObject.OnInteract();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<IInteractive>() == null) return;
        
        _focusObject = other.GetComponent<IInteractive>();
        UpdateKeyHUD();
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<IInteractive>() == null) return;
        
        _focusObject.OnExitInteract();
        _focusObject = null;
        UpdateKeyHUD();
    }

    //Show the "E" interaction icon, the ideal would be to do it in a separate class and communicate it by events, but I had to prioritize other tasks.
    public void UpdateKeyHUD()
    {
        interactKeyHUD.SetActive(_focusObject != null); 
    }
}
