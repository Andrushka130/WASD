using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public class Katana_lvl3 : Weapon, IMeleeWeapon
{
    public override string Category => WeaponName.Katana;
    public override string Name => WeaponName.Katana + WeaponName.Lvl_3;
    public override string Description => "Bla bla bla bla lalalalalalalalalalalalala....";
    public override int WeaponLevel => 3;
    public override int Value => 10;
    public override float Dmg => 10;
    public override float CritDmg => 1.75f;
    public override int CritChance => 20;
    public override float Lifesteal => 0;
    public override float AtkSpeed => 0.5f;    
    public override Rarity RarityType => Rarity.Rare;
    public GameObject AttackPrefab { get; set; }
    public Transform FirePoint { get; set; }
    public Transform FirePointBack { get; set; }

    public override Sprite Icon => Resources.Load<Sprite>(WeaponIconPath.KatanaIcon);

    public float Timer { get; set; }

    private float lifeTime = 0.25f;
    private void Start()
    {
        AttackPrefab = Resources.Load(WeaponAttacks.Katana + WeaponAttacks.Lvl_3) as GameObject;
        FirePoint = GameObject.Find(WeaponFirePoints.FirePointMelee).transform;
        FirePointBack = GameObject.Find(WeaponFirePoints.FirePointLeft).transform;
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
