using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana_lvl3 : Weapon, IMeleeWeapon
{
    public override string Name => "Katana";
    public override float Dmg => 10;
    protected override float CritDmg => 1.75f;
    protected override int CritChance => 20;
    protected override float Lifesteal => 0;
    protected override float AtkSpeed => 0.5f;    
    protected override rarity RarityType => rarity.common;
    public override int WeaponLevel => 3;
    public GameObject AttackPrefab { get; set; }
    public Transform FirePoint { get; set; }
    public Transform FirePointBack { get; set; }

    public float Timer { get; set; }

    private float lifeTime = 0.25f;
    private void Start()
    {
        AttackPrefab = Resources.Load("MeleeAttacks/KatanaSwipes/KatanaSwipe_3") as GameObject;
        FirePoint = GameObject.Find("firePointMelee").transform;
        FirePointBack = GameObject.Find("firePointLeft").transform;
    }

    public void SwingWeapon()
    {
        GameObject blade = Instantiate(AttackPrefab, FirePoint.position, FirePoint.rotation);
        GameObject blade2 = Instantiate(AttackPrefab, FirePointBack.position, FirePointBack.rotation);
        Destroy(blade, lifeTime);
        Destroy(blade2, lifeTime);
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
