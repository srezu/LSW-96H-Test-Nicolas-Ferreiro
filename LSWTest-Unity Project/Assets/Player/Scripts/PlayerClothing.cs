using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerClothing : MonoBehaviour
{
    public Clothing[] playerClothing;
    public void Update()
    {

        UpdatePlayerClothes();
    }

    public void UpdatePlayerClothes()
    {
        foreach (var clothing in playerClothing)
        {
               clothing.clothingItem.ToggleClothing(true);
               clothing.clothingItem.UpdateClothingData(clothing.clothingSlot.clothingData);
        }
    }
}



[Serializable] public struct Clothing
{
    public ClothingItem clothingItem;
    public InventorySlot clothingSlot;
}

