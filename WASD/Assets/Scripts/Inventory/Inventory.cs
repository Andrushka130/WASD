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
            currentChar.MaxHealth.AddModifier(newItem.MaxHealth);
            
            currentChar.Attack.AddModifier(newItem.Attack);
            currentChar.CritChance.AddModifier(newItem.CritChance);
            currentChar.CritDamage.AddModifier(newItem.CritDamage);
            currentChar.AttackSpeed.AddModifier(newItem.AttackSpeed);

            currentChar.Luck.AddModifier(newItem.Luck);
            currentChar.MovementSpeed.AddModifier(newItem.MovementSpeed);
            currentChar.MaxPsychoLevel.AddModifier(newItem.MaxPsychoLevel);
            currentChar.CurrentPsychoLevel.AddModifier(newItem.PsychoLevel);
        }
    }

    public List<Item> PassiveItems => passiveItems;
}
