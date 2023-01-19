using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

public class GorillaArms_lvl3 : Weapon, IMeleeWeapon
{
    public override string Name => "GorillaArms";
    public override float Dmg => 20;
    protected override float CritDmg => 2f;
    protected override int CritChance => 10;
    protected override float Lifesteal => 0;
    protected override float AtkSpeed => 1f;
    protected override rarity RarityType => rarity.rare;
    public override int WeaponLevel => 1;
    public GameObject AttackPrefab { get; set; }
    public Transform FirePoint { get; set; }

    public float Timer { get; set; }

    private float lifeTime = 0.25f;


    private void Start()
    {
        AttackPrefab = Resources.Load("MeleeAttacks/GorillaArm/GorillaArm_lvl3") as GameObject;
        FirePoint = GameObject.Find("firePointMelee").transform;
    }

    public void SwingWeapon()
    {
        GameObject gorillaArm = Instantiate(AttackPrefab, FirePoint.position, FirePoint.rotation);
        Destroy(gorillaArm, lifeTime);
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
