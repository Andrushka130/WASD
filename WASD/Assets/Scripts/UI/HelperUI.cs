using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelperUI : MonoBehaviour
{
    
    public static void FillItemsIcon (List<IBuyable> equippedItems, Transform iconTemplate, Transform container)
    {
        foreach (IBuyable item in equippedItems)
      {
        Transform itemUI = Instantiate(iconTemplate, container); 
        itemUI.GetComponent<Image>().sprite = item.Icon;
      }
    }

    public static List<Transform> FillAttributes ( Transform template, Transform container, bool isShop = false){

      ICharacters character = CharactersManager.CurrentChar; 
      List<Attribute> attributes = character.GetAttributes();
      List<Transform> attributeUIs = new List<Transform>();

      foreach(Attribute attribute in attributes)
      {
        Transform attributeUI = Instantiate(template, container);
        attributeUI.Find("Icon").GetComponent<Image>().sprite = attribute.Icon;
        attributeUI.Find("TextAttributLevel").GetComponent<TextMeshProUGUI>().text = attribute.GetValue().ToString();

        if(isShop)
        {
          attributeUI.Find("PlusButton").GetComponent<PlusButton>().Attribute =  attribute;
          attributeUI.Find("PlusButton").GetComponent<PlusButton>().AttributeUI = attributeUI;
        }

        attributeUI.gameObject.SetActive(true);
        attributeUIs.Add(attributeUI);
      
      }
      return attributeUIs;
      
    }

    public static void UpdateAttributes(List<Transform> attributeUIs){
      ICharacters character = CharactersManager.CurrentChar; 
      List<Attribute> attributes = character.GetAttributes();
      int i = 0;
      foreach(Attribute attribute in attributes)
      {
        attributeUIs[i].Find("TextAttributLevel").GetComponent<TextMeshProUGUI>().text = attribute.GetValue().ToString();
        Debug.Log(attribute.Name + attribute.GetValue().ToString());
        i++;
        
      }
             
    }
}
