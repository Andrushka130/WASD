using UnityEngine;

public interface IBuyable 
{
    int Value {get;}
    string Description {get;}
    string Name {get;}
    Sprite Icon {get;}
    Rarity RarityType {get;}
}
