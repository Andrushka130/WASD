using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public class Hacking_lvl2 : Hacking
{    
    public override string Name => WeaponName.Hacking + WeaponName.Lvl_2;
    public override string Description => "Upgrade: Now fires 2 hacks at once. Even killing is a remote job now";
    public override int WeaponLevel => 2;
    public override int Value => 7;
    public override float Dmg => 6;
    public override float CritDmg => 1.5f;
    public override int CritChance => 25;    
    public override float AtkSpeed => 0.75f;    
    public override Rarity RarityType => Rarity.Uncommon;        
    protected override GameObject BulletPrefab { get; set; }
    protected override Transform FirePoint { get; set; }
    private Transform FirePointLeft { get; set; }    
    protected override float FireForce => 6f;    

    private void Start()
    {
        BulletPrefab = Resources.Load(WeaponAttacks.Hacking + WeaponAttacks.Lvl_2) as GameObject;
    }

    public override void InstantiateWeaponPrefab()
    {

        FirePoint = GameObject.Find(WeaponFirePoints.FirePoint).transform;
        FirePointLeft = GameObject.Find(WeaponFirePoints.FirePointLeft).transform;
        
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        GameObject bullet2 = Instantiate(BulletPrefab, FirePointLeft.position, FirePointLeft.rotation);        

        bullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.right * FireForce, ForceMode2D.Impulse);
        bullet2.GetComponent<Rigidbody2D>().AddForce(-FirePointLeft.right * FireForce, ForceMode2D.Impulse);
        FindObjectOfType<AudioManager>().Play("Hacking");       
    }
}
    

