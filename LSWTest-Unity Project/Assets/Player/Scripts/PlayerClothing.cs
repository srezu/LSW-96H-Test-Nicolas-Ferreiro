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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var clothing in playerClothing)
            {
                clothing.clothingItem.ToggleClothing(true);
                clothing.clothingItem.UpdateClothingData(clothing.clothingData);
            }
        }


    }
}



[Serializable] public struct Clothing
{
    public ClothingItem clothingItem; 
    public ClothingData clothingData;
}

