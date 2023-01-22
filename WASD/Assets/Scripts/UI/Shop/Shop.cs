using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Shop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCoins;

    [SerializeField] private Transform itemTemplate;

    [SerializeField] private Transform itemContainer;


   
    void Awake()
    {
        //InitializeItemShop();
    }

    public void ContinueGame()
    {
      SceneManager.UnloadSceneAsync("Shop");
      Time.timeScale = 1f;
    }

   /*  private void InitializeItemShop(){
      UpdateCoins();
      List<object> buyableItems = ShopManager.GetItems(4);

      foreach (Object item in buyableItems)
      {
        Transform itemUI = Instantiate(itemTemplate, itemContainer); 
       // itemUI.Find("BuyButton").
       if(item is Weapon)
        {
          Weapon weapon = (Weapon) item;
          itemUI.Find("DescriptionText").GetComponent<TextMeshProUGUI>().text = weapon.Description;
          itemUI.Find("NameText").GetComponent<TextMeshProUGUI>().text = weapon.Name;
          itemUI.Find("PriceValueText").GetComponent<TextMeshProUGUI>().text = weapon.Value.ToString();
        } 
        else
        {
          Item passiveItem = (Item) item;
          itemUI.Find("DescriptionText").GetComponent<TextMeshProUGUI>().text = passiveItem.description;
          itemUI.Find("NameText").GetComponent<TextMeshProUGUI>().text = passiveItem.name;
          itemUI.Find("PriceValueText").GetComponent<TextMeshProUGUI>().text = passiveItem.value.ToString();

        }


        

      }

    } */

    private void UpdateCoins(){
      textCoins.text = WalletManager.Wallet.ToString();
    }

    private void InitializeAttributeShop(){

    }
}
