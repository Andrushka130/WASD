using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory instance;
    private static Characters currentChar;
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
        currentChar = CharactersManager.CurrentChar;
    }

    void Start()
    {
        passiveItems = new List<Item>();
    }

    // Adds an item to the inventory
    public bool AddItem(Item item)
    {
        passiveItems.Add(item);
        OnItemAdded(item);
        return true;
    }

    private void OnItemAdded (Item newItem)
    {
        if (newItem != null)
        {
            currentChar.MaxHealth.AddModifier(newItem.maxHealth);
            
            currentChar.Attack.AddModifier(newItem.attack);
            currentChar.CritChance.AddModifier(newItem.critChance);
            currentChar.CritDamage.AddModifier(newItem.critDamage);
            currentChar.AttackSpeed.AddModifier(newItem.attackSpeed);

            currentChar.Luck.AddModifier(newItem.luck);
            currentChar.MovementSpeed.AddModifier(newItem.movementSpeed);
            currentChar.CurrentPsychoLevel.AddModifier(newItem.psychoLevel);
        }
    }

    public List<Item> PassiveItems{ get { return passiveItems; }}
}
