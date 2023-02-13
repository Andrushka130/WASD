using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public class Revolver_lvl2 : Revolver, IRangedWeapon, IBuyable
{    
    public override string Name => WeaponName.Revolver + WeaponName.Lvl_2;
    public override string Description => "Upgrade: Bullet now bounces 2 times.";
    public override int WeaponLevel => 2;
    public override int Value => 10;
    public override float Dmg => 10;
    public override float CritDmg => 1.75f;
    public override int CritChance => 15;
    public override float Lifesteal => 0;
    public override float AtkSpeed => 1f;    
    public override Rarity RarityType => Rarity.Rare;        
    public GameObject BulletPrefab { get; set; }
    public Transform FirePoint { get; set; }
    public float FireForce => 30f;  

    private void Start()
    {
        BulletPrefab = Resources.Load(WeaponAttacks.Revolver + WeaponAttacks.Lvl_2) as GameObject;
        FirePoint = GameObject.Find(WeaponFirePoints.FirePoint).transform;
    }

    public override void InstantiateWeaponPrefab()
    {
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.right * FireForce, ForceMode2D.Impulse);
        FindObjectOfType<AudioManager>().Play("Revolver");
    }
    
}
