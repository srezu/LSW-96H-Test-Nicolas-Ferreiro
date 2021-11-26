using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Animator anim;

    public int coins;
    public TextMeshProUGUI coinsText;

    public InventorySlot[] playerInventorySlots;

    public GameObject commerceWindow;
    public bool commerceResult = false;
        
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

    private void CallUpdateCoins(params object[] x)
    {
        if (!(x[0] is UpdatePlayerCoinsDP)) return;
        UpdatePlayerCoinsDP dp = (UpdatePlayerCoinsDP)x[0];
        
        UpdateCoins(dp.coins);
    }

    public void UpdateCommerceResult(bool playerAnswer)
    {
        commerceResult = playerAnswer;
    }
    
    public void UpdateCoins(int newCoins)
    {
        coins += newCoins;
        coinsText.text = coins.ToString();
    }

    private void  CallToggleInventory(params object[] x)
    {
        if (!(x[0] is ToggleInventoryDP)) return;
        ToggleInventoryDP dp = (ToggleInventoryDP)x[0];
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
