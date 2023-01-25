using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public class Katana_lvl1 : Weapon, IMeleeWeapon
{
    public override string Name => WeaponName.Katana + WeaponName.Lvl_1;
    public override string Description => "pointy stabby thing";
    public override int WeaponLevel => 1;
    public override int Value => 5;
    public override float Dmg => 2;
    public override float CritDmg => 1.2f;
    public override int CritChance => 30;
    public override float Lifesteal => 0;
    public override float AtkSpeed => 1f;    
    public override Rarity RarityType => Rarity.Common;
    public GameObject AttackPrefab { get; set; }
    public Transform FirePoint { get; set; }

    public override Sprite Icon => Resources.Load<Sprite>(WeaponIconPath.KatanaIcon);

    public float Timer { get; set; }

    private float lifeTime = 0.25f;


    private void Start()
    {
        AttackPrefab = Resources.Load(WeaponAttacks.Katana) as GameObject;
        FirePoint = GameObject.Find(WeaponFirePoints.FirePointMelee).transform;
    }

    public void SwingWeapon()
    {
        GameObject blade = Instantiate(AttackPrefab, FirePoint.position, FirePoint.rotation);
        Destroy(blade, lifeTime);
    }

    public override void Attack()
    {
        Timer += Time.deltaTime;
        if (Timer > GetCooldown())
        {
            SwingWeapon();
            Timer = 0;
        }
    }

    public override void DestroyScript(){
        Destroy(this);
    }
}
