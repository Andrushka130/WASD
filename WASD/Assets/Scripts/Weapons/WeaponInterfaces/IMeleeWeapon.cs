using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMeleeWeapon 
{
    GameObject AttackPrefab { get; }
    public void SwingWeapon();

    Transform FirePoint { get; }
   

}
