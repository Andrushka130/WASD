using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private IRangedWeapon[] rangedWeapons;     
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        rangedWeapons = gameObject.GetComponents<IRangedWeapon>();             
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var weapon in rangedWeapons)
        {
            weapon.automaticShooting();            
        }
    }
}
