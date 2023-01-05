using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunchSystem_lvl1 : WeaponClass, IProjectileLaunchWeapon
{
    protected override string Name => "ProjectileLaunchSystem";
    public override float Dmg => 4;
    protected override float CritDmg { get; }
    protected override float CritChance { get; }
    protected override float Lifesteal { get; }
    protected override float AtkSpeed { get; }
    protected override int UpgradeLevel { get; }
    protected override rarity RarityType { get; }

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
        GameObject explosion = Instantiate(bulletPrefab, enemy.transform.position, enemy.transform.rotation);
    }

    public void automaticShooting()
    {
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            FireBullet();
            timer = 0;
        }
    }  

    
}
