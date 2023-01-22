using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory instance;
    private static PlayerAttribute player;
    private List<Item> passiveItems;

    public static Inventory Instance
    {
        get { return instance; }
    }

    void Awake ()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
        player = PlayerAttribute.Instance;
    }

    void Start()
    {
        passiveItems = new List<Item>();
    }

    // Adds an item to the inventory
    public bool AddItem(Item item)
    {
        passiveItems.Add(item);
        player.OnItemAdded(item);
        return true;
    }
}
