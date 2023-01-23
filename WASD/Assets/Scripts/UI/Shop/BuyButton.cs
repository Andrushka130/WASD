using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyButton : MonoBehaviour, IPointerClickHandler
{
   
   private object item;
   private Transform itemUI;

   [SerializeField] private Shop shop;

  





   
   public void OnPointerClick(PointerEventData eventData)
   {
      int result = GameObject.Find("GameManager").GetComponent<ShopManager>().BuyItem(item);
      if (result == 1)
      {
        shop.RemoveShopItem(itemUI);
        Destroy(itemUI.gameObject);
        shop.UpdateCoins();
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