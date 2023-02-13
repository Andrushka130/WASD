using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Shop : MonoBehaviour
{
    


    [SerializeField] private Transform iconTemplate;

    [SerializeField] private Transform weaponsIconContainer;

    [SerializeField] private Transform itemsIconContainer;

    [SerializeField] private Transform attributeTemplate;

    [SerializeField] private Transform attributeContainer;

    [SerializeField] private Transform skillPointsText;


    [SerializeField] private ItemShop itemShop;

    private List<Transform> attributes;

   

  








   
    void Awake()
    {
        /*WeaponInventory weaponInventory = WeaponInventory.GetInstance();
        List<IBuyable> weapons =  weaponInventory.GetWeapons(); 
        HelperUI.FillItemsIcon( weapons, iconTemplate, weaponsIconContainer);

        Inventory itemInventory = Inventory.Instance;
        List<IBuyable> items = itemInventory.PassiveItems;
        HelperUI.FillItemsIcon( items, iconTemplate, itemsIconContainer);
        */

        


        
        itemShop.FillItemShop(4);

        UpdateSkillPoints();
              
        attributes = HelperUI.FillAttributes( attributeTemplate, attributeContainer, true);
    }

    public void ContinueGame()
    {
      SceneManager.UnloadSceneAsync("Shop");
      Time.timeScale = 1f;
    }
   
    public void UpdateSkillPoints()
    {
      int skillPoints = GameObject.Find("Player").GetComponent<ExpSystem>().skillPoints;
      if(skillPoints > 0)
      {
      skillPointsText.GetComponent<TextMeshProUGUI>().text = "+ " + skillPoints;
      }
      else 
      {
        skillPointsText.GetComponent<TextMeshProUGUI>().text = "0";
      }
      

    }

    
}
