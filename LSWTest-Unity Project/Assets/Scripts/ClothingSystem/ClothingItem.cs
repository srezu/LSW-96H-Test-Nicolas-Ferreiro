using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ClothingItem : MonoBehaviour
{    
    [Header("Clothing Parameters")]
    public ClothingRenderer[] clothingRenderer;

    [Header("Clothing Data")]
    public ClothType clothingType;
    public int clothingPrice;
    public string clothingName;
    [TextArea]public string clothingDescription;
    
    public void UpdateClothingData(ref ClothingData clothingData)
    {
        foreach (var playerClothing in clothingRenderer)
        {
            if (clothingData == null)
            {
                playerClothing.clothingSpriteFront.sprite = null;
                playerClothing.clothingSpriteBack.sprite = null;
                playerClothing.clothingSpriteLeft.sprite = null;
                
                clothingPrice = 0;
                clothingName = "";
                clothingDescription = "";
                continue;
            }

            if (clothingData.clothingType != this.clothingType)
            {
                Debug.LogWarning("clothing type doesn't match");
                clothingData = null;
                continue;
            }
            
            playerClothing.clothingSpriteFront.sprite = clothingData.clothingSprite.clothingSpriteFront;
            playerClothing.clothingSpriteBack.sprite = clothingData.clothingSprite.clothingSpriteBack;
            playerClothing.clothingSpriteLeft.sprite = clothingData.clothingSprite.clothingSpriteLeft;


            clothingPrice = clothingData.clothingPrice;
            clothingName = clothingData.clothingName;
            clothingDescription = clothingData.clothingDescription;
            
        }

    }


    public void ToggleClothing(bool toggle)
    {
        foreach (var playerClothing in clothingRenderer)
        {
            playerClothing.clothingSpriteFront.enabled = toggle;
            playerClothing.clothingSpriteBack.enabled = toggle;
            playerClothing.clothingSpriteLeft.enabled = toggle;
        }
           
    }
}
[Serializable] public struct ClothingRenderer {
    public SpriteRenderer clothingSpriteFront;
    public SpriteRenderer clothingSpriteBack;
    public SpriteRenderer clothingSpriteLeft;
}