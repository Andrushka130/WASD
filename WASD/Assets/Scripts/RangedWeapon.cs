using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon : Weapon
{
    protected abstract bool BulletIsTravelthrough { get; }
}
