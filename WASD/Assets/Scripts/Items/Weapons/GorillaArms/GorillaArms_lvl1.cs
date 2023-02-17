using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public class GorillaArms_lvl1 : GorillaArms
{
    
    public override string Name => WeaponName.GorillaArms + WeaponName.Lvl_1;
    public override string Description => "Pushes the enemy away.";
    public override int WeaponLevel => 1;
    public override int Value => 7;
    public override float Dmg => 4;
    public override float CritDmg => 1.5f;
    public override int CritChance => 20;    
    public override float AtkSpeed => 1.5f;    
    public override Rarity RarityType => Rarity.Uncommon;        
    protected override GameObject AttackPrefab { get; set; }
    protected override Transform FirePoint { get; set; }   
    protected override float WeaponLifetime => 0.25f;

    private void Start()
    {
        AttackPrefab = Resources.Load(WeaponAttacks.GorillaArm) as GameObject;        
    }  
}
