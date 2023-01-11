using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class ShopManager : MonoBehaviour
{
    private static Inventory inventory;
    private static ItemFactory itemFactory;
    private static List<Item> shopItems;

    private void Awake()
    {
        inventory = Inventory.Instance;
        shopItems = itemFactory.GetItems();
    }

    public void BuyItem(Item item)
    {
        if(CoinManager.Coins < item.Price)
        {
            return;
        }
        CoinManager.RemoveCoin(item.Price);
        inventory.AddItem(item);
        shopItems.Remove(item);
        Debug.Log("bought Item");
        return;
    }


    //Say you have 4 events

    //event A, relative probability: 4
    //event B, relative probability: 1
    //event C, relative probability: 1
    //event D, relative probability: 10

    //The sum of relative probabilities is 16, so generate a random number X in the range [0,16). Four of those numbers should map to A, one to B, etc.

    //subtract 4 from X. If X is now negative, pick event A.
    //else, subtract 1 from X. If X is now negative, pick event B.
    //else, subtract 1 from X. If X is now negative, pick event C.
    //else, Pick event D.

    public List<Item> GetShopItems(int number)
    {
        System.Random rnd = new System.Random();
        List<Item> randomItems = new List<Item>();
        
        int rarityCount = Enum.GetNames(typeof(itemRarety)).Length;
        int sumOfProbabilities = 0;

        for(int i = 1; i <= rarityCount; i++)
        {
            sumOfProbabilities += i;
        }
        
        for(int i = 0; i < number; i++)
        {
            int rarity = rnd.Next(0, sumOfProbabilities);
            for(int a = rarityCount; a > 0; a--)
            {
                if((rarity - a) < 0)
                {
                    List<Item> itemsOfSameRarity = shopItems.Select(item => Array.IndexOf(Enum.GetValues(item.RarityType.GetType()), item.RarityType) == (rarityCount - a));
                    int randomIndex = rnd.Next(0, itemsOfSameRarity.Length);
                    randomItems.Add(itemsOfSameRarity[randomIndex]);
                }
                rarity -= a;
            }
        }
        return randomItems;
    } 
}