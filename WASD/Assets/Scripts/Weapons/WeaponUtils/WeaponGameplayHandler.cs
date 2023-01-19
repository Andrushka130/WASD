using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGameplayHandler : MonoBehaviour
{
    private WeaponStorage storage;

    void Start(){
        storage = GameObject.Find("WeaponStorage").GetComponent<WeaponStorage>();
    }      
    
    void Update()
    {
        foreach(var weapon in storage.GetWeapons())
        {
            weapon.attack();
        } 
    }

    
}
