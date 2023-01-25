using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelperUI : MonoBehaviour
{
    
    public static void FillItemsIcon (List<object> equippedItems, Transform iconTemplate, Transform parentContainer)
    {
        foreach (object item in equippedItems)
      {
        Transform itemUI = Instantiate(iconTemplate, parentContainer); 
       // itemUI.Find("BuyButton").
       if(item is Weapon)
        {
          Weapon weapon = (Weapon) item;
          itemUI.GetComponent<Image>().sprite = weapon.Icon;
          
          
        } 
        else
        {
          Item passiveItem = (Item) item;
          itemUI.GetComponent<Image>().sprite = passiveItem.icon;

        }   


    }
    }
}
