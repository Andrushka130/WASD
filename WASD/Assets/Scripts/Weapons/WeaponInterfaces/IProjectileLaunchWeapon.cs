using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IProjectileLaunchWeapon
{
    GameObject BulletPrefab { get; set; }
    public EnemyDetectionCircle EnemyDetectionCircle { get; set; }
    float Timer { get; set; }  
    public void FireBullet();
    
}
