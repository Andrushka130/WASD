using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

public class GorillaArms_lvl2 : Weapon, IMeleeWeapon
{
    public override string Name => "GorillaArms";
    public override string Description => "I am going to use Lorem ipsum from now on...";
    public override int WeaponLevel => 2;
    public override int Value => 10;
    public override float Dmg => 12;
    public override float CritDmg => 1.75f;
    public override int CritChance => 15;
    public override float Lifesteal => 0;
    public override float AtkSpeed => 1.2f;
    public override Rarity RarityType => Rarity.Rare;
    public GameObject AttackPrefab { get; set; }
    public Transform FirePoint { get; set; }

    public float Timer { get; set; }

    private float lifeTime = 0.25f;


    private void Start()
    {
        AttackPrefab = Resources.Load("MeleeAttacks/GorillaArm/GorillaArm_lvl2") as GameObject;
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
