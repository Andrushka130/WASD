using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver_lvl2 : Weapon, IRangedWeapon
{
    public override string Name => "Revolver";
    public override float Dmg => 10;
    protected override float CritDmg => 1.75f;
    protected override int CritChance => 15;
    protected override float Lifesteal => 0;
    protected override float AtkSpeed => 1f;    
    protected override rarity RarityType => rarity.rare;
    public override int WeaponLevel => 2;
    public bool BulletIsTravelthrough { get; } = false;
    public float Timer { get; set; }
    public GameObject BulletPrefab { get; set; }
    public Transform FirePoint { get; set; }
    public float FireForce => 30f;

    private void Start()
    {
        BulletPrefab = Resources.Load("Bullets/RevolverBullets/RevolverBullet_lvl2") as GameObject;
        FirePoint = GameObject.Find("firePoint").transform;
    }

    public void FireBullet()
    {
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.right * FireForce, ForceMode2D.Impulse);
    }

    public override void Attack()
    {
        Timer += Time.deltaTime;
        if (Timer > GetCooldown())
        {
            FireBullet();
            Timer = 0;
        }
    }
}
