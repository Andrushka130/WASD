using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject, IBuyable
{
    [SerializeField] new private string name = "New Item";
    public bool isPassiveItem = true;
    [SerializeField] private Sprite icon = null;
    [SerializeField] private Rarity rarityType;
    [SerializeField] private int value;
    [SerializeField] private string description = "This item harbors secrets that the developer will reveal soon.";       //Default Text

    // Attributes for every item
    public int attack;
    public int critChance;
    public int critDamage;
    public int attackSpeed;
    public int maxHealth;
    public int healthRegen;
    public int lifesteal;
    public int luck;
    public int movementSpeed;
    public int psychoLevel;

   
    public string Name { get { return name; }}
    public Sprite Icon { get { return icon; }}
    public Rarity RarityType { get { return rarityType; }}
    public int Value { get { return value; }}
    public string Description { get { return description; }}
}
