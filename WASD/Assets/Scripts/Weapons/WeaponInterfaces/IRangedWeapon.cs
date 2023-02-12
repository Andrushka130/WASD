using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 interface IRangedWeapon
{
    GameObject BulletPrefab { get; }
    Transform FirePoint { get; }
    float FireForce { get; }   
    
}
    

    
    
