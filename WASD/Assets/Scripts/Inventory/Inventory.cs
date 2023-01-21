using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory instance = null;
    private static readonly object padlock = new object();
    private static PlayerAttribute1 player;
    private List<Item> passiveItems;

    private Inventory()
    {
    }

    public static Inventory Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Inventory();
                }
                return instance;
            }
        }
    }

    public List<Item> Items
    {
        get { return passiveItems; }
    }
    
    void Start()
    {
        // Initialize the lists
        passiveItems = new List<Item>();
    }

    public bool AddItem(Item item)
    {
        passiveItems.Add(item);
        player.OnItemAdded(item);
        return true;
    }
}
