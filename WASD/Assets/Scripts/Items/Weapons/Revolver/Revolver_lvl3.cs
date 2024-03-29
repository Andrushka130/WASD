using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public class Revolver_lvl3 : Revolver
{    
    public override string Name => WeaponName.Revolver + WeaponName.Lvl_3;
    public override string Description => "Upgrade: Bullet now bounces 5 times.";
    public override int WeaponLevel => 3;
    public override int Value => 15;
    public override float Dmg => 15;
    public override float CritDmg => 2f;
    public override int CritChance => 10;    
    public override float AtkSpeed => 1f;
    public override Rarity RarityType => Rarity.Epic;    
    public override GameObject BulletPrefab { get; set; }
    protected override Transform FirePoint { get; set; }
    public override float FireForce => 20f;     

    private void Start()
    {
        BulletPrefab = Resources.Load(WeaponAttacks.Revolver + WeaponAttacks.Lvl_3) as GameObject;        
    }      
}
