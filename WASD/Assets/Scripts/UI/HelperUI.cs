using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelperUI : MonoBehaviour
{
    
    public static void FillItemsIcon (List<object> equippedItems, Transform iconTemplate, Transform container)
    {
        foreach (object item in equippedItems)
      {
        Transform itemUI = Instantiate(iconTemplate, container); 
    
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

    public static void FillAttributes ( Transform template, Transform container, bool isShop = false){

      ICharacters character = CharactersManager.CurrentChar; 
      List<Attribute> attributes = character.GetAttributes();

      foreach(Attribute attribute in attributes)
      {
        Transform attributeUI = Instantiate(template, container);
        attributeUI.Find("Icon").GetComponent<Image>().sprite = attribute.Icon;
        attributeUI.Find("TextAttributLevel").GetComponent<TextMeshProUGUI>().text = attribute.GetValue().ToString();

        if(isShop)
        {
          attributeUI.Find("PlusButton").GetComponent<PlusButton>().Attribute = attribute;
          attributeUI.Find("PlusButton").GetComponent<PlusButton>().AttributeUI = attributeUI;
        }

        attributeUI.gameObject.SetActive(true); 
        

      }
      
    }
}
