using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunchSystem_lvl1 : Weapon, IProjectileLaunchWeapon
{
    public override string Name => "ProjectileLaunchSystem";
    public override float Dmg => 4;
    protected override float CritDmg { get; }
    protected override float CritChance { get; }
    protected override float Lifesteal { get; }
    protected override float AtkSpeed { get; }   
    protected override rarity RarityType { get; }
    public override int WeaponLevel => 1;

    public GameObject bulletPrefab { get; set; }
    public EnemyDetectionCircle enemyDetectionCircle { get; set; }
    public float timer { get; set; }
    public float cooldown { get; set; } = 2f;

    private void Start()
    {
        enemyDetectionCircle = new EnemyDetectionCircle();
        bulletPrefab = Resources.Load("Bullets/ProjectileLaunchSystemProjectile/ProjectileExplosion") as GameObject;
    }

    public void FireBullet()
    {
        Collider2D enemy;
        enemy = enemyDetectionCircle.getFirstEnemyAroundPlayer(10f);       

        if(enemy.TryGetComponent<EnemyAI>(out EnemyAI enemyAI)){
            GameObject bullet = Instantiate(bulletPrefab, enemy.transform.position, enemy.transform.rotation);
            Destroy(bullet, 0.25f);
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
