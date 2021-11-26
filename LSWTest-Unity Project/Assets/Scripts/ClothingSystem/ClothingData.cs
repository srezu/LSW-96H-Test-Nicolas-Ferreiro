using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ScriptableObject template for clothing info, it could be more generic, but in this one I almost decided to do it like this for the simplicity of the project
[CreateAssetMenu(fileName = "New clothing", menuName = "Clothing")]
public class ClothingData : ScriptableObject
{
    public ClothingSprites clothingSprite;
    public ClothType clothingType;
    public int clothingPrice;
    public string clothingName;
    [TextArea]public string clothingDescription;

}

public enum ClothType {CLOTHING_Armor, CLOTHING_Helmet, CLOTHING_Leg, None}; //This indicates the type of clothing or object that it will be, it could be expanded to add weapons or other clothing.
[Serializable] public struct ClothingSprites {
    public Sprite clothingSpriteFront;
    public Sprite clothingSpriteBack;
    public Sprite clothingSpriteLeft;
}