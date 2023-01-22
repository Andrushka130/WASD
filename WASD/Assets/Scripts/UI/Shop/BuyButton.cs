using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyButton : MonoBehaviour, IPointerClickHandler
{
   [SerializeField]
   private object item;
   
   public void OnPointerClick(PointerEventData eventData)
   {
      ShopManager.BuyItem(item);
   }

    public object Item
  {
    set { item = value; }
  }


   

}