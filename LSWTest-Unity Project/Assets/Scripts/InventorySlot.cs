using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
   [Header(("Slot"))]
   public Image iconRenderer;
   public Button slotButton;
   [Header(("Clothing data"))]
   public ClothingData clothingData;

  

   private void Update()
   {
      UpdateInventorySlot();

      

      slotButton.interactable = clothingData != null;
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
