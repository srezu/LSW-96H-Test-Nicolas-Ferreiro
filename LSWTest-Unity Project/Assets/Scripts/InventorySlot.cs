using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
   public Image iconRenderer;
   public ClothingData clothingData;



   private void Update()
   {
      UpdateInventorySlot();
   }

   public void UpdateInventorySlot()
   {
      
      if (clothingData == null)
      {
         iconRenderer.enabled = false;
         return;
      }


      iconRenderer.enabled = true;
      iconRenderer.sprite = clothingData.clothingSprite.clothingSpriteFront;
   }
}
