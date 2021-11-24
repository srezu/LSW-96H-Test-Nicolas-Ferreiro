using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//template for clothing

[CreateAssetMenu(fileName = "New clothing", menuName = "Clothing")]
public class ClothingData : ScriptableObject
{
    public ClothingSprites clothingSprite;
    public ClothType clothingType;
    public int clothingPrice;
    public string clothingName;
    [TextArea]public string clothingDescription;

    


}

public enum ClothType {CLOTHING_Armor, CLOTHING_Helmet, CLOTHING_LLegArmor, CLOTHING_RLegArmor};
[Serializable] public struct ClothingSprites {
    public Sprite clothingSpriteFront;
    public Sprite clothingSpriteBack;
    public Sprite clothingSpriteLeft;
}