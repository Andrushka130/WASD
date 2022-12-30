using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 interface IRangedWeapon
{
    bool BulletIsTravelthrough { get; }
    float timer { get; set; }
    float cooldown { get; set; }
    GameObject bulletPrefab { get; }
    Transform firePoint { get; }
    float fireForce { get; }
    public void automaticShooting();
    public void FireBullet();

}
    

    
    
