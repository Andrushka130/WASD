using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IProjectileLaunchWeapon
{
    GameObject bulletPrefab { get; set; }
    public EnemyDetectionCircle enemyDetectionCircle { get; set; }
    float timer { get; set; }
    float cooldown { get; set; }    
    public void FireBullet();
    
}
