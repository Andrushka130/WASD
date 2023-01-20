using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;
    public static PlayerAttribute1 player;

    void Awake ()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }
    
    #endregion

    // The maximum number of items that can be held in the weapon inventory
    public int weaponInventorySize = 6;

    // The list of passive items in the inventory
    public List<Item> passiveItems;

    // The list of weapons in the inventory
    public List<Item> weapons;

    void Start()
    {
        // Initialize the lists
        passiveItems = new List<Item>();
        weapons = new List<Item>();
    }

    // Adds an item to the inventory
    public bool AddItem(Item item)
    {
        if (item.isPassiveItem)
        {
            // Add the passive item to the list
            passiveItems.Add(item);
            player.OnItemAdded(item);
            return true;
        }
        else
        {
            // If the weapon inventory is full, send message
            if(weapons.Count >= weaponInventorySize)
            {
                Debug.Log("You already have enough Weapons!");
                return false;
            }
            else
            {
                // Add the weapon to the list
                weapons.Add(item);
                return true;
            }
        }
    }

    public void Remove (Item item)
    {
        if (!item.isPassiveItem)
        {
            weapons.Remove(item);
        }
        else
        {
            Debug.LogWarning("You can't remove Items that are not Weapons!");
        }
    }
}
