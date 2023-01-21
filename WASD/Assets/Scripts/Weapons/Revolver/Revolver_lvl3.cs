using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver_lvl3 : Weapon, IRangedWeapon
{
    public override string Name => "Revolver";
    public override float Dmg => 15;
    protected override float CritDmg => 2f;
    protected override int CritChance => 10;
    protected override float Lifesteal => 0;
    protected override float AtkSpeed => 1f;
    protected override Rarity RarityType => Rarity.Epic;
    public override int WeaponLevel => 3;
    public bool BulletIsTravelthrough { get; } = false;
    public float Timer { get; set; }
    public GameObject BulletPrefab { get; set; }
    public Transform FirePoint { get; set; }
    public float FireForce => 20f;

    private void Start()
    {
        BulletPrefab = Resources.Load("Bullets/RevolverBullets/RevolverBullet_lvl3") as GameObject;
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

    public override void DestroyScript(){
        Destroy(this);
    }
}
