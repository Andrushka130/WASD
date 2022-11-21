using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MeleeWeapon, IUpgradable
{
    protected override string Name => "Katana";
    protected override float Dmg => 5;
    protected override float CritDmg => 0.5f;
    protected override float CritChance => 0.15f;
    protected override float Lifesteal => 3;
    protected override float AtkSpeed => 0.2f;
    protected override int UpgradeLevel => 1;
    protected override rarity RarityType => rarity.common;   
    protected override float AtkRange => 3;    
    
    public void upgradeWeapon(rarity rarityType)
    {
        Debug.Log("Upgrading weapon");
    }        
    
}
