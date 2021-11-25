using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using  UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour,IDropHandler
{
   [Header(("Slot"))]
   public Image iconRenderer;
   public Button slotButton;
   public ClothType slotType;//for exclusive types of slots
   public bool exclusiveSlot;
   [Header(("Clothing data"))]
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
   
   public void OnDrop(PointerEventData eventData)
   {
      if (eventData.pointerDrag != null && clothingData == null)
      {
         Debug.Log("DROP in " +gameObject.name);
         var oldInventorySlot = eventData.pointerDrag.gameObject.GetComponentInParent<InventorySlot>();
         
         if (oldInventorySlot == this) return;

         if (exclusiveSlot && oldInventorySlot.clothingData.clothingType != slotType) return;

         clothingData = oldInventorySlot.clothingData;
         oldInventorySlot.Clear();
      }
      else
      {
      //   Debug.Log("DROP failed! ");
      }
   }

   public void Clear()
   {
      clothingData = null;
   }
}
