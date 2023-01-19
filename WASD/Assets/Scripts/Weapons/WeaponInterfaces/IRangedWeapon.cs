using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 interface IRangedWeapon
{
    bool BulletIsTravelthrough { get; }
    float Timer { get; set; }
    GameObject BulletPrefab { get; }
    Transform FirePoint { get; }
    float FireForce { get; }    
    public void FireBullet();

}
    

    
    
