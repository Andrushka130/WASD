using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    private static List<Item> itemList;

    public static List<Item> List
    {
        get {return itemList;}
    }

    void Start()
    {
        //Create a List, containing all Items that are in the Resources Folder
        itemList = new List<Item>(Resources.LoadAll<Item>("Assets/Scripts/Inventory/Items"));
    }
}
