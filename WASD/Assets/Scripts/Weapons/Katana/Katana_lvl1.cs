using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana_lvl1 : WeaponClass, IMeleeWeapon
{
    protected override string Name => "Katana_lvl1";
    public override float Dmg => 3;
    protected override float CritDmg => 0.5f;
    protected override float CritChance => 0.15f;
    protected override float Lifesteal => 0;
    protected override float AtkSpeed => 0.2f;
    protected override int UpgradeLevel => 1;
    protected override rarity RarityType => rarity.common;
    public GameObject attackPrefab { get; set; }
    public Transform firePoint { get; set; }

    public float timer { get; set; }
    public float cooldown { get; set; } = 2f;

    private float lifeTime = 0.25f;


    private void Start()
    {
        attackPrefab = Resources.Load("MeleeSwipes/KatanaSwipes/KatanaSwipe_1") as GameObject;
        firePoint = GameObject.Find("firePointMelee").transform;
    }

    public void swingWeapon()
    {
        GameObject blade = Instantiate(attackPrefab, firePoint.position, firePoint.rotation);
        Destroy(blade, lifeTime);
    }

    public void automaticAttack()
    {
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            swingWeapon();
            timer = 0;
        }
    }

}
