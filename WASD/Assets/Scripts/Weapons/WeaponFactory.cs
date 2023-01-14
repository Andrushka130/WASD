using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponFactory 
{
    private Weapon[] weapons;
    private Weapon searchedWeapon;     

    public void initializeWeaponsArray()
    {
        weapons = GameObject.Find("WeaponFactory").GetComponents<Weapon>();
    }

    public Weapon getSpecificWeapon(string weaponName, int weaponLevel)
    {     
        initializeWeaponsArray();

        arrayNotInitializedCheck(weapons);

        foreach (var weapon in weapons)
        {            
            if(weapon.Name == weaponName && weapon.WeaponLevel == weaponLevel)
            {
                searchedWeapon = weapon;
            }                       
        }

        noWeaponFoundCheck(searchedWeapon);

        return searchedWeapon;        
    }   

    public Weapon[] getWeaponsArray()
    {
        initializeWeaponsArray();
        return weapons;
    }

    private void noWeaponFoundCheck(Weapon weapon)
    {
        if(weapon == null)
        {
            Debug.LogWarning("No weapon was found. Wrong weapon name or weapon level.");
            throw new NullReferenceException();
        }
    }

    private void arrayNotInitializedCheck(Weapon[] weapons)
    {
        if (weapons.Length == 0 || weapons == null)
        {
            Debug.LogWarning("Weapons array from weaponFactory was not initialized! Weapon components in the WeaponFactory gameObject could be missing.");
            throw new Exception();
        }
    }

}
