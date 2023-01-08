using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

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

    public Item item;

    // The maximum number of items that can be held in the weapon inventory
    public int weaponInventorySize = 5;

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
        if ((int)item.type == 0)
        {
            // Add the passive item to the list
            passiveItems.Add(item);
            return true;
        }
        else if ((int)item.type == 1)
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
        else{
            // Item type is not in the permitted range
            Debug.LogWarning("Type of Item is not defined");
            return false;
        }
    }

    public void Remove (Item item)
    {
        if ((int)item.type == 1)
        {
            weapons.Remove(item);
        }
        else
        {
            Debug.LogWarning("You can't remove Items that are not Weapons!");
        }
    }
}
