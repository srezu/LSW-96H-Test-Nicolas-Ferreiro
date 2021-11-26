using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/*This class is responsible for updating the appearance of the character based on the scriptableObject,
 this allows the player to change clothes quickly and easily.*/
public class ClothingItem : MonoBehaviour
{    
    [Header("Clothing Parameters")]
    public ClothingRenderer[] clothingRenderer;//contains a reference to the renderer sprite to which the clothes should be assigned, it is a struct because the player has several directions (front, back, left) in which the clothes can be displayed.

    //this data is filled by the scriptableObject
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