using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private IRangedWeapon[] rangedWeapons;
    private IMeleeWeapon[] meleeWeapons;
    private IProjectileLaunchWeapon[] p;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        rangedWeapons = gameObject.GetComponents<IRangedWeapon>();
        meleeWeapons = gameObject.GetComponents<IMeleeWeapon>();
        p = gameObject.GetComponents<IProjectileLaunchWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var weapon in rangedWeapons)
        {
            weapon.automaticShooting();            
        }

        foreach(var weapon in meleeWeapons)
        {
            weapon.automaticAttack();
        }

        foreach(var weapon in p)
        {
            weapon.automaticShooting();
        }
    }
}
