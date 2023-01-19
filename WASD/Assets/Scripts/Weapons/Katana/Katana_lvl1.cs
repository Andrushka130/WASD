using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana_lvl1 : Weapon, IMeleeWeapon
{
    public override string Name => "Katana";
    public override float Dmg => 2;
    protected override float CritDmg => 1.2f;
    protected override int CritChance => 30;
    protected override float Lifesteal => 0;
    protected override float AtkSpeed => 1f;    
    protected override rarity RarityType => rarity.common;
    public override int WeaponLevel => 1;
    public GameObject AttackPrefab { get; set; }
    public Transform FirePoint { get; set; }

    public float Timer { get; set; }

    private float lifeTime = 0.25f;


    private void Start()
    {
        AttackPrefab = Resources.Load("MeleeAttacks/KatanaSwipes/KatanaSwipe_1") as GameObject;
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

}
