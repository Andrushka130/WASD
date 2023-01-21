using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana_lvl2 : Weapon, IMeleeWeapon
{
    public override string Name => "Katana";
    public override string Description => "Not a good back scratcher";
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

    public float Timer { get; set; }

    private float lifeTime = 0.25f;


    private void Start()
    {
        AttackPrefab = Resources.Load("MeleeAttacks/KatanaSwipes/KatanaSwipe_2") as GameObject;
        FirePoint = GameObject.Find("firePointMelee").transform;
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