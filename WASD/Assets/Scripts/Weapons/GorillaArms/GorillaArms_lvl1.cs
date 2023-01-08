using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaArms_lvl1 : Weapon, IMeleeWeapon
{
    protected override string Name => "GorillaArms";
    public override float Dmg => 0;
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
        attackPrefab = Resources.Load("MeleeAttacks/GorillaArm/GorillaArm") as GameObject;
        firePoint = GameObject.Find("firePointMelee").transform;
    }

    public void swingWeapon()
    {
        GameObject gorillaArm = Instantiate(attackPrefab, firePoint.position, firePoint.rotation);
        Destroy(gorillaArm, lifeTime);
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
}
