using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGameplayHandler : MonoBehaviour
{
    private WeaponStorage storage = new WeaponStorage();         
    
    void Update()
    {
        foreach(var weapon in storage.getWeapons())
        {
            weapon.Attack();
        } 
    }

    
}
