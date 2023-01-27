using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public class GorillaArms_lvl1 : GorillaArms, IMeleeWeapon
{
    
    public override string Name => WeaponName.GorillaArms + WeaponName.Lvl_1;
    public override string Description => "Pushes the enemy away.";
    public override int WeaponLevel => 1;
    public override int Value => 7;
    public override float Dmg => 4;
    public override float CritDmg => 1.5f;
    public override int CritChance => 20;
    public override float Lifesteal => 0;
    public override float AtkSpeed => 1.5f;    
    public override Rarity RarityType => Rarity.Uncommon;        
    public GameObject AttackPrefab { get; set; }
    public Transform FirePoint { get; set; }   
    public float WeaponLifetime => 0.25f;

    private void Start()
    {
        AttackPrefab = Resources.Load(WeaponAttacks.GorillaArm) as GameObject;
        FirePoint = GameObject.Find(WeaponFirePoints.FirePointMelee).transform;
    }

    public override void InstantiateWeaponPrefab()
    {
        GameObject gorillaArm = Instantiate(AttackPrefab, FirePoint.position, FirePoint.rotation);
        Destroy(gorillaArm, WeaponLifetime);
    }
   
}
