using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{    
    private Weapon[] weapons;    
    
    void Start()
    {             
        weapons = gameObject.GetComponents<Weapon>();
    }

    
    void Update()
    {        
        foreach(var weapon in weapons)
        {
            weapon.Attack();
            
        }        
    }
}
