using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyButton : MonoBehaviour, IPointerClickHandler
{
   
   private object item;
   private Transform itemUI;

   [SerializeField] private ItemShop itemShop;

  
   
   public void OnPointerClick(PointerEventData eventData)
   {
      EShop result = GameObject.Find("GameManager").GetComponent<ShopManager>().BuyItem(item);
      FindObjectOfType<AudioManager>().Play("BuyingItem");
      if (result == EShop.BoughtItem)
      {
        itemShop.RemoveShopItem(itemUI);
        Destroy(itemUI.gameObject);
        itemShop.UpdateCoins();
      } 
      else if (result == EShop.NotEnoughMoney)
      {
        itemShop.SetAlertText("Not enough money!");
      }
      else if (result == EShop.WeaponInventoryFull)
      {
        itemShop.SetAlertText("You can only have four Weapon!");
      }
      else if (result == EShop.PsychoLevelToHigh)
      {
        itemShop.SetAlertText("Psycho level is too high. Please skill in psycho level.");
      }
      
      
   }

    public object Item
  {
    set { item = value; }
  }

   public Transform ItemUI
  {
    set { itemUI = value; }
  }

 

   

}