using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class ShopManager : MonoBehaviour
{
    private static Characters currentChar;
    private static Inventory _inventory;
    private static WeaponInventory _weaponInventory;
    private static WeaponHandler _weaponHandler;
    private static List<Item> items;
    private static List<List<Weapon>> weapons;
    
    private void Start() {
        currentChar = CharactersManager.CurrentChar;
        _inventory = Inventory.Instance;
        _weaponHandler = new WeaponHandler();
        _weaponInventory = WeaponInventory.GetInstance();
        items = ItemList.List;
        weapons  = _weaponInventory.GetWeaponTypeList();
        Debug.Log(GetItems(4));
    }


    //returns 0 if not enough money
    //returns 1 if item bought
    //returns -1 if weapon inventory full
    public EShop BuyItem(object item)
    {
        if(item is Weapon)
        {
            Weapon weapon = (Weapon) item;
            if(WalletManager.Wallet < weapon.Value)
            {
                return EShop.NotEnoughMoney;
            }
            if(!_weaponHandler.InsertNewWeapon(weapon))
            {
                Debug.Log("Weapon inventory is full");
                return EShop.WeaponInventoryFull;
            }
            WalletManager.RemoveMoney(weapon.Value);
            foreach(List<Weapon> w in weapons)
            {
                if (w.Contains(weapon))
                {
                    w.Remove(weapon);
                }
            }
            Debug.Log("bought weapon: " + weapon.Name);
            return EShop.BoughtItem;
        }
        
        Item passiveItem = (Item) item;
        if((currentChar.CurrentPsychoLevelValue + passiveItem.psychoLevel) <= currentChar.MaxPsychoLevelValue)
        {    if(WalletManager.Wallet < passiveItem.value)
            {
                return EShop.NotEnoughMoney;
            }
            WalletManager.RemoveMoney(passiveItem.value);
            _inventory.AddItem(passiveItem);

        
            Debug.Log("bought item: " + passiveItem.name);
            return EShop.BoughtItem;
        }
        return EShop.PsychoLevelToHigh;
    }


    public List<object> GetItems(int amount)
    {
        System.Random rnd = new System.Random();

        int[] probabilities = (int[])Enum.GetValues(typeof(Rarity));
        int rarityCount = probabilities.Length;

        List<object> shopItems = GetShopItems();

        List<object> randomItems = new List<object>();
        

        for (int i = 0; i < amount; i++)
        {
            float rarity = rnd.Next(1, 101);
            if((rarity + currentChar.LuckValue) > 100)
            {
                rarity = 100;
            }
            else
            {
                rarity += currentChar.LuckValue;
            }

            for(int a = 0; a < rarityCount; a++)
            {
                //Example: rarity is 56
                // first step: 56 is not in range of Common(1 - 40) so 56 - 40 is not smaller then 0
                // => rarity -= 40
                // rarity is 16
                // second step: 16 is in range of Uncommon(1 - 30) so 16 - 30 is smaller then 0
                // => an item with rarity Uncommon gets selected
                if(!((rarity - probabilities[a])  < 0))
                {
                    rarity -= probabilities[a];
                } 
                else 
                {
                    List<object> itemsOfSameRarity = new List<object>();
                    foreach(object item in shopItems)
                    {
                        if(item is Weapon)
                        {
                            Weapon weapon = (Weapon) item;
                            if((int) weapon.RarityType == probabilities[a])
                            {
                                itemsOfSameRarity.Add((object) weapon);
                            }
                        }
                        else
                        {
                            Item passiveItem = (Item) item;
                            if((int) passiveItem.RarityType == probabilities[a])
                            {
                                itemsOfSameRarity.Add((object) passiveItem);
                            }
                        }
                    }
                    

                    if(itemsOfSameRarity.Count == 0)
                    {
                        i--;
                        break;
                    }
                
                    int randomIndex = rnd.Next(0, itemsOfSameRarity.Count);

                    if(itemsOfSameRarity[randomIndex] is Weapon)
                    {
                        if(randomItems.Contains(itemsOfSameRarity[randomIndex]))
                        {
                            i--;
                            break;
                        }
                    }

                    randomItems.Add(itemsOfSameRarity[randomIndex]);
                    break;
                }
            }
        }
        return randomItems;
    }

    private List<object> GetShopItems()
    {
        List<object> shopItems = (from x in items select (object) x).ToList();
        shopItems.AddRange((from x in GetNextWeaponLevel() select (object) x).ToList());

        return shopItems;
    }

    private List<Weapon> GetNextWeaponLevel()
    {
        List<Weapon> nextWeaponLevels = new List<Weapon>();
        foreach(List<Weapon> weapon in weapons)
        {
            nextWeaponLevels.Add(weapon[0]);
        }

        return nextWeaponLevels;
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

    /* public List<Item> GetShopItems(int number)
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
    }  */
}