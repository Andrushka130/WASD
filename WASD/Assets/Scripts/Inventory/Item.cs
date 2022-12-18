using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public string description;

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
