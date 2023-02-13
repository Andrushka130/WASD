using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public class Katana_lvl2 : Katana, IMeleeWeapon, IBuyable
{    
    public override string Name => WeaponName.Katana + WeaponName.Lvl_2;
    public override string Description => "Upgrade: Increased area of attack.";
    public override int WeaponLevel => 2;
    public override int Value => 7;
    public override float Dmg => 6;
    public override float CritDmg => 1.5f;
    public override int CritChance => 25;
    public override float Lifesteal => 0;
    public override float AtkSpeed => 0.75f;
    public override Rarity RarityType => Rarity.Uncommon;
    public GameObject AttackPrefab { get; set; }
    public Transform FirePoint { get; set; }    
    public float WeaponLifetime => 0.25f;


    private void Start()
    {
        AttackPrefab = Resources.Load(WeaponAttacks.Katana + WeaponAttacks.Lvl_2) as GameObject;
        FirePoint = GameObject.Find(WeaponFirePoints.FirePointMelee).transform;
    }

    public override void InstantiateWeaponPrefab()
    {
        GameObject blade = Instantiate(AttackPrefab, FirePoint.position, FirePoint.rotation);
        FindObjectOfType<AudioManager>().Play("Katana");
        Destroy(blade, WeaponLifetime);
    }   

}
