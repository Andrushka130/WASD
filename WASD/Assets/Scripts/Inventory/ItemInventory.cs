using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{

    #region Singleton

    public static ItemInventory instance;

    void Awake ()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of ItemInventory found!");
            return;
        }
        instance = this;
    }
    
    #endregion

    public List<Item> items = new List<Item>();

    public void Add (Item item)
    {
        items.Add(item);
    }

}
