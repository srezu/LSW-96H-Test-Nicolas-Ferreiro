using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using  UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour,IDropHandler
{
   
   
   [Header(("Slot"))]
   public Image iconRenderer;
   public Button slotButton;
   public InventorySlotOwner owner;
   
   [Header(("SlotType"))]
   public ClothType slotType;//for exclusive types of slots
   public bool checkSlotType;

   [Header(("SlotPrice"))] 
   public bool showPrice;
   public GameObject priceContainer;
   public TextMeshProUGUI priceText;
   
   [Header(("Clothing data"))]
   public ClothingData clothingData;

   private void Start()
   {
      UpdateInventorySlot();
   }

   public void UpdateInventorySlot()
   {
      
      if (clothingData == null)
      {
         iconRenderer.enabled = false;
         priceContainer.SetActive(false);
         return;
      }

      priceText.text = clothingData.clothingPrice.ToString();
      priceContainer.SetActive(showPrice);
   
      iconRenderer.enabled = true;
      iconRenderer.sprite = clothingData.clothingSprite.clothingSpriteFront;
   }
   
   public void OnDrop(PointerEventData eventData)
   {
  
      if (eventData.pointerDrag != null && clothingData == null)
      {
         var oldInventorySlot = eventData.pointerDrag.gameObject.GetComponentInParent<InventorySlot>();
         if (oldInventorySlot == this) return;
         if (checkSlotType && oldInventorySlot.clothingData.clothingType != slotType) return;


         if (oldInventorySlot.owner == InventorySlotOwner.Merchant && owner == InventorySlotOwner.Player)
         {//buy item
           
            EventManager.Call(Constantes.UpdatePlayerCoins, new UpdatePlayerCoinsDP() { coins = -oldInventorySlot.clothingData.clothingPrice});
         }
         else
         {//sell item
            EventManager.Call(Constantes.UpdatePlayerCoins, new UpdatePlayerCoinsDP() { coins = oldInventorySlot.clothingData.clothingPrice});
         }
         
         clothingData = oldInventorySlot.clothingData;
         oldInventorySlot.Clear();
         oldInventorySlot.UpdateInventorySlot();
         UpdateInventorySlot();
      }
   
      
 
   }

   public void Clear()
   {
      clothingData = null;
   }
}

public enum InventorySlotOwner
{
   Player,
   Merchant
}