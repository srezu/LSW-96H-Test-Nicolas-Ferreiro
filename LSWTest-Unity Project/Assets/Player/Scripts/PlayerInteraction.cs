using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerInteraction : MonoBehaviour
{
    public IInteractive focusObject;
    public GameObject interactKeyHUD;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if(_playerInput.interact) Interact();
        
    }

    public void Interact()
    {
        if(focusObject != null) focusObject.OnInteract();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<IInteractive>() == null) return;
        
  
        focusObject = other.GetComponent<IInteractive>();
        UpdateKeyHUD();
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<IInteractive>() == null) return;
        focusObject.OnExitInteract();
        focusObject = null;

        UpdateKeyHUD();
    }

    public void UpdateKeyHUD()
    {
        interactKeyHUD.SetActive(focusObject != null);

    }
}
