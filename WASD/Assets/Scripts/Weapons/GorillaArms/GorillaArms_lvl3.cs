using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;
using static Weapon;

public class GorillaArms_lvl3 : Weapon, IMeleeWeapon
{
    public override string Category => WeaponName.GorillaArms;
    public override string Name => WeaponName.GorillaArms + WeaponName.Lvl_3;
    public override string Description => "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.";
    public override int WeaponLevel => 3;
    public override int Value => 15;
    public override float Dmg => 20;
    public override float CritDmg => 2f;
    public override int CritChance => 10;
    public override float Lifesteal => 0;
    public override float AtkSpeed => 1f;
    public override Rarity RarityType => Rarity.Epic;
    public GameObject AttackPrefab { get; set; }
    public Transform FirePoint { get; set; }

    public override Sprite Icon => Resources.Load<Sprite>(WeaponIconPath.GorillaArmsIcon);

    public float Timer { get; set; }

    private float lifeTime = 0.25f;


    private void Start()
    {
        AttackPrefab = Resources.Load(WeaponAttacks.GorillaArm + WeaponAttacks.Lvl_3) as GameObject;
        FirePoint = GameObject.Find(WeaponFirePoints.FirePointMelee).transform;
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
