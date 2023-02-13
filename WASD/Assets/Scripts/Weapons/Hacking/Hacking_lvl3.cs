using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public class Hacking_lvl3 : Hacking, IBuyable
{    
    public override string Name => WeaponName.Hacking + WeaponName.Lvl_3;
    public override string Description => "Upgrade: Now fires 4 hacks at once.";
    public override int WeaponLevel => 3;
    public override int Value => 10;
    public override float Dmg => 15;
    public override float CritDmg => 1.75f;
    public override int CritChance => 20;
    public override float Lifesteal => 0;
    public override float AtkSpeed => 0.5f;    
    public override Rarity RarityType => Rarity.Rare;        
    public override GameObject BulletPrefab { get; set; }
    public override Transform FirePoint { get; set; }
    private Transform FirePointLeft { get; set; }
    private Transform FirePointUp { get; set; }
    private Transform FirePointDown { get; set; }
    public override float FireForce => 8f;


    private void Start()
    {
        BulletPrefab = Resources.Load(WeaponAttacks.Hacking + WeaponAttacks.Lvl_3) as GameObject;
        FirePoint = GameObject.Find(WeaponFirePoints.FirePoint).transform;
        FirePointLeft = GameObject.Find(WeaponFirePoints.FirePointLeft).transform;
        FirePointUp = GameObject.Find(WeaponFirePoints.FirePointUp).transform;
        FirePointDown = GameObject.Find(WeaponFirePoints.FirePointDown).transform;
    }

    public override void InstantiateWeaponPrefab()
    {
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        GameObject bulletLeft = Instantiate(BulletPrefab, FirePointLeft.position, FirePointLeft.rotation);
        GameObject bulletUp = Instantiate(BulletPrefab, FirePointUp.position, FirePointUp.rotation);
        GameObject bulletDown = Instantiate(BulletPrefab, FirePointDown.position, FirePointDown.rotation);

        bullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.right * FireForce, ForceMode2D.Impulse);
        bulletLeft.GetComponent<Rigidbody2D>().AddForce(-FirePointLeft.right * FireForce, ForceMode2D.Impulse);
        bulletUp.GetComponent<Rigidbody2D>().AddForce(FirePointUp.up * FireForce, ForceMode2D.Impulse);
        bulletDown.GetComponent<Rigidbody2D>().AddForce(-FirePoint.up * FireForce, ForceMode2D.Impulse);
    }
}
