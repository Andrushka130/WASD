using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject, IBuyable
{
    public bool isPassiveItem = true;
    [SerializeField] private int value;
    [SerializeField] private string description = "This item harbors secrets that the developer will reveal soon."; //Default Text
    [SerializeField] new private string name = "New Item";
    [SerializeField] private Sprite icon = null;
    [SerializeField] private Rarity rarityType;
    
    // Attributes for every item
    [SerializeField] private int attack;
    [SerializeField] private int critChance;
    [SerializeField] private int critDamage;
    [SerializeField] private int attackSpeed;
    [SerializeField] private int maxHealth;
    [SerializeField] private int luck;
    [SerializeField] private int movementSpeed;
    [SerializeField] private int psychoLevel;
    [SerializeField] private int maxPsychoLevel;

   
    public int Value => value; 
    public string Description => description; 
    public string Name => name; 
    public Sprite Icon => icon; 
    public Rarity RarityType => rarityType; 
    public int Attack => attack;
    public int CritChance => critChance;
    public int CritDamage => critDamage;
    public int AttackSpeed => attackSpeed;
    public int MaxHealth => maxHealth;
    public int Luck => luck;
    public int MovementSpeed => movementSpeed;
    public int PsychoLevel => psychoLevel;
    public int MaxPsychoLevel => maxPsychoLevel;
}
