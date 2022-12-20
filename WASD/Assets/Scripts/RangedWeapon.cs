using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon : WeaponClass
{
    protected abstract bool BulletIsTravelthrough { get; }
}
