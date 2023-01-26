using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public class Revolver_lvl3 : Weapon, IRangedWeapon
{
    public override string Category => WeaponName.Revolver;
    public override string Name => WeaponName.Revolver + WeaponName.Lvl_3;
    public override string Description => "Orcas are natural predators of moose";
    public override int WeaponLevel => 3;
    public override int Value => 15;
    public override float Dmg => 15;
    public override float CritDmg => 2f;
    public override int CritChance => 10;
    public override float Lifesteal => 0;
    public override float AtkSpeed => 1f;
    public override Rarity RarityType => Rarity.Epic;
    public bool BulletIsTravelthrough { get; } = false;

    public override Sprite Icon => Resources.Load<Sprite>(WeaponIconPath.RevolverIcon);
    public float Timer { get; set; }
    public GameObject BulletPrefab { get; set; }
    public Transform FirePoint { get; set; }
    public float FireForce => 20f;

    private void Start()
    {
        BulletPrefab = Resources.Load(WeaponAttacks.Revolver + WeaponAttacks.Lvl_3) as GameObject;
        FirePoint = GameObject.Find(WeaponFirePoints.FirePoint).transform;
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
