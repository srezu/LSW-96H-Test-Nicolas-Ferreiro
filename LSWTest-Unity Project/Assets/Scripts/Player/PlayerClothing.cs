using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/*This class acts as an intermediary between the player's clothing and inventory.
Indicate which clothing slot corresponds to each part of the character's body.*/
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
            clothing.clothingItem.UpdateClothingData(ref clothing.clothingSlot.clothingData);
        }
    }
}



[Serializable] public struct Clothing
{
    public ClothingItem clothingItem;
    public InventorySlot clothingSlot;
}

