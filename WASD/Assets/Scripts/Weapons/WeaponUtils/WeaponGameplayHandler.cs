using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGameplayHandler : MonoBehaviour
{    private WeaponInventory inventory;

    void Start(){
        inventory = WeaponInventory.getInstance();
    }      
    
    void Update()
    {
        foreach(var weapon in inventory.GetWeapons())
        {
            weapon.Attack();
        } 
    }

    
}
