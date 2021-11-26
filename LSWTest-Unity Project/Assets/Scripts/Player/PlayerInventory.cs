using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/*This class is in charge of managing the player's inventory,*/
public class PlayerInventory : MonoBehaviour
{

    [Header("Inventory")]
    public InventorySlot[] playerInventorySlots;
    
    [Header("Player coins")]
    public int coins;
    public TextMeshProUGUI coinsText;


    [Header("Other")]
    public Animator anim;
    public GameObject commerceWindow;
    private bool _commerceResult = false;
        
    private void Start()
    {
        UpdateCoins(0);
        foreach (var inventorySlot in playerInventorySlots)
        {
            inventorySlot.playerInventory = this;
        }
    }

    private void OnEnable()
    {
        EventManager.Subscribe(Constantes.ToggleInventory, CallToggleInventory);
        EventManager.Subscribe(Constantes.UpdatePlayerCoins, CallUpdateCoins);
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe(Constantes.ToggleInventory, CallToggleInventory);
        EventManager.Unsubscribe(Constantes.UpdatePlayerCoins, CallUpdateCoins);
    }
    public void UpdateCommerceResult(bool playerAnswer)
    {
        _commerceResult = playerAnswer;
    }
    

    //Add or subtract money from the player from another script.
    private void CallUpdateCoins(params object[] x)
    {
        if (!(x[0] is UpdatePlayerCoinsDP)) return;
        var dp = (UpdatePlayerCoinsDP)x[0];
        
        UpdateCoins(dp.coins);
    }
    public void UpdateCoins(int newCoins)
    {
        coins += newCoins;
        coinsText.text = coins.ToString();
    }

    
    //It is used to activate / deactivate the player's inventory from another script.
    private void  CallToggleInventory(params object[] x)
    {
        if (!(x[0] is ToggleInventoryDP)) return;
        var dp = (ToggleInventoryDP)x[0];
        ToggleInventory(dp.toggle);
    }
    public void ToggleInventory(bool toggle)
    {
        if (toggle)
        {
            anim.Play("OpenInventory");
        }
        else
        {
            anim.Play("CloseInventory");
        }
    }
}
