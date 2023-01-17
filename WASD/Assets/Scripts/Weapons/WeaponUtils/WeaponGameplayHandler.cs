using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGameplayHandler : MonoBehaviour
{
    private WeaponStorage storage = new WeaponStorage();
    private Weapon[] equipedWeapons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var weapon in equipedWeapons)
        {
            weapon.attack();
        } 
    }

    
}
