using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunchSystem_lvl1 : Weapon, IProjectileLaunchWeapon
{
    public override string Name => "ProjectileLaunchSystem";
    public override string Description => "\"Projectile\" leaves room for imagination";
    public override int WeaponLevel => 1;
    public override int Value => 10;
    public override float Dmg => 10;
    public override float CritDmg => 2f;
    public override int CritChance => 10;
    public override float Lifesteal => 0;
    public override float AtkSpeed => 2f;
    public override Rarity RarityType => Rarity.Rare;

    public GameObject BulletPrefab { get; set; }
    public EnemyDetectionCircle EnemyDetectionCircle { get; set; }
    public float Timer { get; set; }

    private void Start()
    {
        EnemyDetectionCircle = new EnemyDetectionCircle();
        BulletPrefab = Resources.Load("Bullets/ProjectileLaunchSystemProjectile/ProjectileExplosion") as GameObject;
    }

    public void FireBullet()
    {
        Collider2D enemy;
        enemy = EnemyDetectionCircle.getFirstEnemyAroundPlayer(10f);       

        if(enemy.TryGetComponent<EnemyAI>(out EnemyAI enemyAI)){
            GameObject bullet = Instantiate(BulletPrefab, enemy.transform.position, enemy.transform.rotation);
            Destroy(bullet, 0.25f);
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