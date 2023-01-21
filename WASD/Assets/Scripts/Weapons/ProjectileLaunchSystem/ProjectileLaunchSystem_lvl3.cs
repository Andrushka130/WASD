using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunchSystem_lvl3 : Weapon, IProjectileLaunchWeapon
{
    public override string Name => "ProjectileLaunchSystem";
    public override string Description => "It tastes funny";
    public override int WeaponLevel => 3;
    public override int Value => 25;
    public override float Dmg => 30;
    public override float CritDmg => 3f;
    public override int CritChance => 4;
    public override float Lifesteal => 0f;
    public override float AtkSpeed => 1f;
    public override Rarity RarityType => Rarity.Legendary;

    public GameObject BulletPrefab { get; set; }
    public EnemyDetectionCircle EnemyDetectionCircle { get; set; }
    public float Timer { get; set; }

    private void Start()
    {
        EnemyDetectionCircle = new EnemyDetectionCircle();
        BulletPrefab = Resources.Load("Bullets/ProjectileLaunchSystemProjectile/ProjectileExplosion_lvl3") as GameObject;
    }

    public void FireBullet()
    {             
               
        Collider2D[] enemys;
        enemys = EnemyDetectionCircle.getEnemysAroundPlayer(20f);                    

        for(int numberOfEnemys = 0; numberOfEnemys <= 2; numberOfEnemys++){
            if(enemys[numberOfEnemys].TryGetComponent<EnemyAI>(out EnemyAI enemyAI)){
                GameObject bullet = Instantiate(BulletPrefab, enemys[numberOfEnemys].transform.position, enemys[numberOfEnemys].transform.rotation);
                Destroy(bullet, 0.25f);
            }
        }   
        
    }

    public override void Attack()
    {
        Timer += Time.deltaTime;
        if (Timer > GetCooldown())
        {
            FireBullet();
            Timer = 0;
        }
    }  

    public override void DestroyScript(){
        Destroy(this);
    }
}