using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemShop : MonoBehaviour
{
    [SerializeField] private Sprite commonSprite;
    [SerializeField] private Sprite uncommonSprite;
    [SerializeField] private Sprite rareSprite;
    [SerializeField] private Sprite epicSprite;
    [SerializeField] private Sprite legendarySprite;

    [SerializeField] private TextMeshProUGUI textCoins;

    [SerializeField] private TextMeshProUGUI alertText;
    [SerializeField] private Transform itemTemplate;
    [SerializeField] private Transform itemContainer;

    private List<Transform> shopItems = new List<Transform>();



    public void FillItemShop(int count)
     {
      UpdateCoins();
      List<object> buyableItems = GameObject.Find("GameManager").GetComponent<ShopManager>().GetItems(count);

      foreach (Object item in buyableItems)
      {
        Transform itemUI = Instantiate(itemTemplate, itemContainer); 
      
       if(item is Weapon)
        {
          Weapon weapon = (Weapon) item;
          itemUI.Find("IconBorder").Find("Icon").GetComponent<Image>().sprite = weapon.Icon;
          itemUI.Find("IconBorder").GetComponent<Image>().sprite = GetRarityBorder(weapon.RarityType);
          itemUI.Find("TextContainer").Find("NameText").GetComponent<TextMeshProUGUI>().text = weapon.Name;
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

        itemUI.gameObject.SetActive(true); 
        shopItems.Add(itemUI);

        itemUI.Find("BuyButton").GetComponent<BuyButton>().Item = item;
        itemUI.Find("BuyButton").GetComponent<BuyButton>().ItemUI = itemUI;

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
        FillItemShop(itemsCount);
      } 
      else if (WalletManager.Wallet < 20)
      {
        SetAlertText("Not enough money!");
      } 
      else 
      {
        SetAlertText("Reroll don't add items in the Shop.");
      }
      
      
    }

    public void RemoveShopItem(Transform item){
      shopItems.Remove(item);

    }

    public void UpdateCoins(){
      textCoins.text = WalletManager.Wallet.ToString()+" €$";
    }

    public void SetAlertText(string message)
    {
      alertText.GetComponent<TextMeshProUGUI>().text = message;
    }


}
