using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public ItemType type;
    public Sprite icon = null;
    public rarity RarityType;

    // Attributes for every item
    public int damage;
    public int critChance;
    public int critDamage;
    public int attackSpeed;
    public int armor;
    public int dodge;
    public int shield;
    public int healthRegen;
    public int lifesteal;
    public int luck;
    public int movementSpeed;
    public int range;
    public int psychoLevel;
}

public enum ItemType
    {
        passiveItem,
        weapon
    }

public enum rarity
    {
        common,
        uncommon,
        rare,
        epic,
        legendary
    }