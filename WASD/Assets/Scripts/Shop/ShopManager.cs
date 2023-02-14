using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class ShopManager : MonoBehaviour
{
    private static ICharacters currentChar;
    private static Inventory _inventory;
    private static WeaponInventory _weaponInventory;
    private static WeaponHandler _weaponHandler;
    private static List<Item> items;
    private static List<List<Weapon>> weapons;


    [SerializeField] private ExpSystem expSystem;

    
    
    private void Start() {
        currentChar = CharactersManager.CurrentChar;
        _inventory = Inventory.Instance;
        _weaponHandler = new WeaponHandler();
        _weaponInventory = WeaponInventory.GetInstance();
        items = ItemList.List;
        weapons  = _weaponInventory.GetWeaponTypeList();
        Debug.Log(GetItems(4));
    }


    public EShop BuyItem(IBuyable item)
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
        {    if(WalletManager.Wallet < passiveItem.Value)
            {
                return EShop.NotEnoughMoney;
            }
            WalletManager.RemoveMoney(passiveItem.Value);
            _inventory.AddItem(passiveItem);

        
            Debug.Log("bought item: " + passiveItem.Name);
            return EShop.BoughtItem;
        }
        return EShop.PsychoLevelToHigh;
    }


    public List<IBuyable> GetItems(int amount)
    {
        System.Random rnd = new System.Random();

        int[] probabilities = (int[]) Enum.GetValues(typeof(Rarity));
        Array.Reverse(probabilities);

        int rarityCount = probabilities.Length;

        List<IBuyable> shopItems = GetShopItems();

        List<IBuyable> randomItems = new List<IBuyable>();
        

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
                if(!((rarity - probabilities[a]) <= 0))
                {
                    rarity -= probabilities[a];
                } 
                else 
                {
                    List<IBuyable> itemsOfSameRarity = new List<IBuyable>();
                    foreach(IBuyable item in shopItems)
                    {
                        if((int) item.RarityType == probabilities[a])
                        {
                            itemsOfSameRarity.Add(item);
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
        Debug.Log(randomItems.Count);
        return randomItems;
    }

    private List<IBuyable> GetShopItems()
    {
        List<IBuyable> shopItems = (from x in items select (IBuyable) x).ToList();
        shopItems.AddRange((from x in GetNextWeaponLevel() select (IBuyable) x).ToList());

        return shopItems;
    }

    private List<Weapon> GetNextWeaponLevel()
    {
        List<Weapon> nextWeaponLevels = new List<Weapon>();
        foreach(List<Weapon> weapon in weapons)
        {
            if(!(weapon.Count == 0))
            {
                nextWeaponLevels.Add(weapon[0]);
            }
        }

        return nextWeaponLevels;
    }

    public void SkillAttribute(Attribute attribute)
    {
        if(expSystem.skillPoints > 0){
            attribute.ChangeAttribute(1);
            expSystem.skillPoints--;
        }
    }
}