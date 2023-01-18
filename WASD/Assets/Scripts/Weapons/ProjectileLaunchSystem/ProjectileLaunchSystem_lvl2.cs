using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunchSystem_lvl2 : Weapon, IProjectileLaunchWeapon
{
    public override string Name => "ProjectileLaunchSystem";
    public override float Dmg => 4;
    protected override float CritDmg { get; }
    protected override float CritChance { get; }
    protected override float Lifesteal { get; }
    protected override float AtkSpeed { get; }   
    protected override rarity RarityType { get; }
    public override int WeaponLevel => 2;

    public GameObject bulletPrefab { get; set; }
    public EnemyDetectionCircle enemyDetectionCircle { get; set; }
    public float timer { get; set; }
    public float cooldown { get; set; } = 2f;

    private void Start()
    {
        enemyDetectionCircle = new EnemyDetectionCircle();
        bulletPrefab = Resources.Load("Bullets/ProjectileLaunchSystemProjectile/ProjectileExplosion_lvl2") as GameObject;        
    }

    public void FireBullet()
    {             
               
        Collider2D[] enemys;
        enemys = enemyDetectionCircle.getEnemysAroundPlayer(20f);                    

        for(int numberOfEnemys = 0; numberOfEnemys <= 1; numberOfEnemys++){
            if(enemys[numberOfEnemys].TryGetComponent<EnemyAI>(out EnemyAI enemyAI)){
                GameObject bullet = Instantiate(bulletPrefab, enemys[numberOfEnemys].transform.position, enemys[numberOfEnemys].transform.rotation);
                Destroy(bullet, 0.25f);
            }
        }   
        
    }

    public override void attack()
    {
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            FireBullet();
            timer = 0;
        }
    }  

    public override void DestroyScript(){
        Destroy(this);
    }
}
