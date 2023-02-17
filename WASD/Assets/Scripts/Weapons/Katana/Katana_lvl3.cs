using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public class Katana_lvl3 : Katana, IBuyable
{    
    public override string Name => WeaponName.Katana + WeaponName.Lvl_3;
    public override string Description => "Upgrade: Now also attacks in an area behind.";
    public override int WeaponLevel => 3;
    public override int Value => 10;
    public override float Dmg => 10;
    public override float CritDmg => 1.75f;
    public override int CritChance => 20;
    public override float Lifesteal => 0;
    public override float AtkSpeed => 0.5f;    
    public override Rarity RarityType => Rarity.Rare;
    protected override GameObject AttackPrefab { get; set; }
    protected override Transform FirePoint { get; set; }
    protected Transform FirePointBack { get; set; }     
    protected override float WeaponLifetime => 0.25f;
    private void Start()
    {
        AttackPrefab = Resources.Load(WeaponAttacks.Katana + WeaponAttacks.Lvl_3) as GameObject;
        FirePoint = GameObject.Find(WeaponFirePoints.FirePointMelee).transform;
        FirePointBack = GameObject.Find(WeaponFirePoints.FirePointLeft).transform;
    }
    public override void InstantiateWeaponPrefab()
    {
        GameObject blade = Instantiate(AttackPrefab, FirePoint.position, FirePoint.rotation);
        GameObject blade2 = Instantiate(AttackPrefab, FirePointBack.position, FirePointBack.rotation);
        FindObjectOfType<AudioManager>().Play("Katana");
        Destroy(blade, WeaponLifetime);
        Destroy(blade2, WeaponLifetime);
    }
    
}
