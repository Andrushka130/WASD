using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMeleeWeapon 
{
    GameObject attackPrefab { get; }
    public void swingWeapon();

    Transform firePoint { get; }
   

}
