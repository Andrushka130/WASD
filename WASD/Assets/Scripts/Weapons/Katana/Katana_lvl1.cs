using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public class Katana_lvl1 : Katana, IBuyable
{    
    public override string Name => WeaponName.Katana + WeaponName.Lvl_1;
    public override string Description => "Attacks in an area in front.";
    public override int WeaponLevel => 1;
    public override int Value => 5;
    public override float Dmg => 2;
    public override float CritDmg => 1.2f;
    public override int CritChance => 30;
    public override float Lifesteal => 0;
    public override float AtkSpeed => 1f;    
    public override Rarity RarityType => Rarity.Common;
    protected override GameObject AttackPrefab { get; set; }
    protected override Transform FirePoint { get; set; }    
    protected override float WeaponLifetime => 0.25f;

    private void Start()
    {
        AttackPrefab = Resources.Load(WeaponAttacks.Katana) as GameObject;       
    }

    public override void InstantiateWeaponPrefab()
    {
        FirePoint = GameObject.Find(WeaponFirePoints.FirePointMelee).transform;
        GameObject blade = Instantiate(AttackPrefab, FirePoint.position, FirePoint.rotation);
        FindObjectOfType<AudioManager>().Play("Katana");
        Destroy(blade, WeaponLifetime);
    }
   
}
