using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelperUI : MonoBehaviour
{
    
    private static void FillIcons (IEnumerable<IBuyable> equippedItems, Transform iconTemplate, Transform container)
    {
      int childs = container.childCount;
        for (int i = childs - 1; i > 0; i--)
        {
            GameObject.Destroy(container.GetChild(i).gameObject);
        }

      foreach (IBuyable item in equippedItems)
      {
        Transform itemUI = Instantiate(iconTemplate, container); 
        itemUI.GetComponent<Image>().sprite = item.Icon;
        itemUI.gameObject.SetActive(true);
      }
    }

    public static void FilltItemIcon(Transform iconTemplate, Transform weaponsContainer, Transform itemsContainer)
    {
      WeaponInventory weaponInventory = WeaponInventory.GetInstance();
      IEnumerable<IBuyable> weapons =  weaponInventory.GetWeapons(); 
      FillIcons( weapons, iconTemplate, weaponsContainer);

      Inventory itemInventory = Inventory.Instance;
      IEnumerable<IBuyable> items = itemInventory.PassiveItems;
      FillIcons( items, iconTemplate, itemsContainer);
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
