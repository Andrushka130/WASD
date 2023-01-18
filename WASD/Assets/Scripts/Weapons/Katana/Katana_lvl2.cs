using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana_lvl2 : Weapon, IMeleeWeapon
{
    public override string Name => "Katana";
    public override float Dmg => 6;
    protected override float CritDmg => 0.5f;
    protected override float CritChance => 0.15f;
    protected override float Lifesteal => 0;
    protected override float AtkSpeed => 0.2f;    
    protected override rarity RarityType => rarity.common;
    public override int WeaponLevel => 2;
    public GameObject attackPrefab { get; set; }
    public Transform firePoint { get; set; }

    public float timer { get; set; }
    public float cooldown { get; set; } = 1f;

    private float lifeTime = 0.25f;


    private void Start()
    {
        attackPrefab = Resources.Load("MeleeAttacks/KatanaSwipes/KatanaSwipe_2") as GameObject;
        firePoint = GameObject.Find("firePointMelee").transform;
    }

    public void swingWeapon()
    {
        GameObject blade = Instantiate(attackPrefab, firePoint.position, firePoint.rotation);
        Destroy(blade, lifeTime);
    }

    public override void attack()
    {
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            swingWeapon();
            timer = 0;
        }
    }

    public override void DestroyScript(){
        Destroy(this);
    }

}
