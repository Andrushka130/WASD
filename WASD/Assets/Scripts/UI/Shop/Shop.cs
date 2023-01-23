using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Shop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCoins;

    [SerializeField] private Transform itemTemplate;

    [SerializeField] private Transform itemContainer;

    [SerializeField] private Sprite commonSprite;
    [SerializeField] private Sprite uncommonSprite;
    [SerializeField] private Sprite rareSprite;
    [SerializeField] private Sprite epicSprite;
    [SerializeField] private Sprite legendarySprite;

    [SerializeField] private List<Transform> shopItems;








   
    void Awake()
    {
        InitializeItemShop(4);
    }

    public void ContinueGame()
    {
      SceneManager.UnloadSceneAsync("Shop");
      Time.timeScale = 1f;
    }

     private void InitializeItemShop(int count){
      UpdateCoins();
      List<object> buyableItems = GameObject.Find("GameManager").GetComponent<ShopManager>().GetItems(count);

      foreach (Object item in buyableItems)
      {
        Transform itemUI = Instantiate(itemTemplate, itemContainer); 
       // itemUI.Find("BuyButton").
       if(item is Weapon)
        {
          Weapon weapon = (Weapon) item;
          itemUI.Find("IconBorder").Find("Icon").GetComponent<Image>().sprite = weapon.Icon;
          itemUI.Find("IconBorder").GetComponent<Image>().sprite = GetRarityBorder(weapon.RarityType);
          itemUI.Find("TextContainer").Find("NameText").GetComponent<TextMeshProUGUI>().text = weapon.Name + " lvl " + weapon.WeaponLevel;
          itemUI.Find("TextContainer").Find("DescriptionText").GetComponent<TextMeshProUGUI>().text = weapon.Description;
          itemUI.Find("PriceTextContainer").Find("PriceValueText").GetComponent<TextMeshProUGUI>().text = weapon.Value.ToString() +" €$";
          
        } 
        else
        {
          Item passiveItem = (Item) item;
          itemUI.Find("IconBorder").GetComponent<Image>().sprite = GetRarityBorder(passiveItem.RarityType);
          itemUI.Find("TextContainer").Find("DescriptionText").GetComponent<TextMeshProUGUI>().text = passiveItem.description;
          itemUI.Find("TextContainer").Find("NameText").GetComponent<TextMeshProUGUI>().text = passiveItem.name;
          itemUI.Find("PriceTextContainer").Find("PriceValueText").GetComponent<TextMeshProUGUI>().text = passiveItem.value.ToString()+" €$";

        }   

        itemUI.Find("BuyButton").GetComponent<BuyButton>().Item = item;
        itemUI.Find("BuyButton").GetComponent<BuyButton>().ItemUI = itemUI;

        itemUI.gameObject.SetActive(true); 
        shopItems.Add(itemUI);

      }

    } 

    private Sprite GetRarityBorder(Rarity rarity)
    {
        switch (rarity)
      {

        case Rarity.Uncommon:
            return uncommonSprite;

        case Rarity.Rare:
            return rareSprite;

        case Rarity.Epic:
            return epicSprite;

        case Rarity.Legendary:
            return legendarySprite;

        default:
            return commonSprite;

      
      }
    }


    public void UpdateCoins(){
      textCoins.text = WalletManager.Wallet.ToString()+" €$";
    }

    private void InitializeAttributeShop(){

    }

    public void Reroll()
    {
      if(WalletManager.Wallet >= 20 && shopItems.Count > 0)
      {
        WalletManager.RemoveMoney(20);
        foreach(Transform item in shopItems)
        {
          Destroy(item.gameObject);
        }
        int itemsCount = shopItems.Count;
        shopItems.Clear();        
        InitializeItemShop(itemsCount);
      }
      
      
    }

    public void RemoveShopItem(Transform item){
      shopItems.Remove(item);

    }
}
