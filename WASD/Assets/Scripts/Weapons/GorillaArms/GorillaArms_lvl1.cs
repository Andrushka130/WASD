using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaArms_lvl1 : Weapon, IMeleeWeapon
{
    public override string Name => "GorillaArms";
    public override string Description => "Funny description";
    public override int WeaponLevel => 1;
    public override int Value => 7;
    public override float Dmg => 4;
    public override float CritDmg => 1.5f;
    public override int CritChance => 20;
    public override float Lifesteal => 0;
    public override float AtkSpeed => 1.5f;    
    public override Rarity RarityType => Rarity.Uncommon;
      
    public GameObject AttackPrefab { get; set; }
    public Transform FirePoint { get; set; }

    public float Timer { get; set; }

    private float lifeTime = 0.25f;


    private void Start()
    {
        AttackPrefab = Resources.Load("MeleeAttacks/GorillaArm/GorillaArm") as GameObject;
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
