using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Shop : MonoBehaviour
{
    


    [SerializeField] private Transform iconTemplate;

    [SerializeField] private Transform weaponIconContainer;

    [SerializeField] private Transform itemsIconContainer;

    [SerializeField] private Transform attributeTemplate;

    [SerializeField] private Transform attributeContainer;

    [SerializeField] private Transform skillPointsText;


    [SerializeField] private ItemShop itemShop;

   

  








   
    void Awake()
    {
        /* WeaponInventory weaponInventory = WeaponInventory.GetInstance();
        List<object> weapon =  weaponInventory.GetWeapons(); */
        //HelperUI.FillImageIcon( weapon, iconTemplate, weaponIconContainer);
        
        itemShop.FillItemShop(4);

        UpdateSkillPoints();
              
        HelperUI.FillAttributes( attributeTemplate, attributeContainer, true);
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
