using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunchSystem_lvl2 : Weapon, IProjectileLaunchWeapon
{
    public override string Name => "ProjectileLaunchSystem";
    public override string Description => "BOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOM";
    public override int WeaponLevel => 2;
    public override int Value => 15;
    public override float Dmg => 20;
    public override float CritDmg => 2.5f;
    public override int CritChance => 7;
    public override float Lifesteal => 0f;
    public override float AtkSpeed => 1.5f;
    public override Rarity RarityType => Rarity.Epic;

    public GameObject BulletPrefab { get; set; }
    public EnemyDetectionCircle EnemyDetectionCircle { get; set; }
    public float Timer { get; set; }

    private void Start()
    {
        EnemyDetectionCircle = new EnemyDetectionCircle();
        BulletPrefab = Resources.Load("Bullets/ProjectileLaunchSystemProjectile/ProjectileExplosion_lvl2") as GameObject;        
    }

    public void FireBullet()
    {             
               
        Collider2D[] enemys;
        enemys = EnemyDetectionCircle.getEnemysAroundPlayer(20f);                    

        for(int numberOfEnemys = 0; numberOfEnemys <= 1; numberOfEnemys++){
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