using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;
using static Weapon;

public class GorillaArms_lvl3 : GorillaArms, IBuyable
{   
    public override string Name => WeaponName.GorillaArms + WeaponName.Lvl_3;
    public override string Description => "Upgrade: Increased push range and larger attack.";
    public override int WeaponLevel => 3;
    public override int Value => 15;
    public override float Dmg => 20;
    public override float CritDmg => 2f;
    public override int CritChance => 10;
    public override float Lifesteal => 0;
    public override float AtkSpeed => 1f;
    public override Rarity RarityType => Rarity.Epic;
    protected override GameObject AttackPrefab { get; set; }
    protected override Transform FirePoint { get; set; }   
    protected override float WeaponLifetime => 0.25f;

    private void Start()
    {
        AttackPrefab = Resources.Load(WeaponAttacks.GorillaArm + WeaponAttacks.Lvl_3) as GameObject;
        FirePoint = GameObject.Find(WeaponFirePoints.FirePointMelee).transform;
    }

    public override void InstantiateWeaponPrefab()
    {
        GameObject gorillaArm = Instantiate(AttackPrefab, FirePoint.position, FirePoint.rotation);
        FindObjectOfType<AudioManager>().Play("GorillaArms");
        Destroy(gorillaArm, WeaponLifetime);
    }

    
}
