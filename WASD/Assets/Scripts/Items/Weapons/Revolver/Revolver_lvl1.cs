using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;
using System;
using System.Text;


public class Revolver_lvl1 : Revolver
{    
    public override string Name => WeaponName.Revolver + WeaponName.Lvl_1;
    public override string Description => "A normal Revolver. Has increased crit chance.";
    public override int WeaponLevel => 1;
    public override int Value => 7;
    public override float Dmg => 5;
    public override float CritDmg => 1.5f;
    public override int CritChance => 30;    
    public override float AtkSpeed => 1.3f;    
    public override Rarity RarityType => Rarity.Uncommon;   
    public override GameObject BulletPrefab { get; set; }
    protected override Transform FirePoint { get; set; }
    public override float FireForce => 30f;        

    private void Start()
    {
        BulletPrefab = Resources.Load(WeaponAttacks.Revolver) as GameObject;        
    }           
}

