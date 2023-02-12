using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMeleeWeapon 
{
    GameObject AttackPrefab { get; }    
    Transform FirePoint { get; }   
    float WeaponLifetime { get; }

}
