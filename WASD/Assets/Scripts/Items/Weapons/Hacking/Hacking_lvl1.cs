using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public class Hacking_lvl1 : Hacking
{    
    public override string Name => WeaponName.Hacking + WeaponName.Lvl_1;
    public override string Description => "Hacks into the enemies system and fries them.";
    public override int WeaponLevel => 1;
    public override int Value => 5;
    public override float Dmg => 3;
    public override float CritDmg => 1.3f;
    public override int CritChance => 20;    
    public override float AtkSpeed => 1f;    
    public override Rarity RarityType => Rarity.Common;          
    protected override GameObject BulletPrefab { get; set; }
    protected override Transform FirePoint { get; set; } 
    protected override float FireForce => 5f;

    private void Start()
    {
        BulletPrefab = Resources.Load(WeaponAttacks.Hacking) as GameObject;        
    }

    public override void InstantiateWeaponPrefab()
    {
        FirePoint = GameObject.Find(WeaponFirePoints.FirePoint).transform;
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.right * FireForce, ForceMode2D.Impulse);
        FindObjectOfType<AudioManager>().Play("Hacking");
    }
}
