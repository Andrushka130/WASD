using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public bool isPassiveItem = true;
    public Sprite icon = null;
    public Rarity RarityType;
    public int value;
    public string description = "This item harbors secrets that the developer will reveal soon.";       //Default Text

    // Attributes for every item
    public int attack;
    public int critChance;
    public int critDamage;
    public int attackSpeed;
    public int armor;
    public int dodge;
    public int shield;
    public int maxHealth;
    public int healthRegen;
    public int lifesteal;
    public int luck;
    public int movementSpeed;
    public int psychoLevel;
}
