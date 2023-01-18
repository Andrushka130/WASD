using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponStorage
{
    private static List<List<Weapon>> weaponTypeList = new List<List<Weapon>>();
    private WeaponFetcher fetcher;
    private static List<Weapon> equipedWeapons;        
    public WeaponStorage()
    {                
        fetcher = new WeaponFetcher();        
        weaponTypeList = fetcher.fillWeaponTypeListFromWeaponStorage();
        equipedWeapons.Add(fetcher.fillWeaponListWithStartingWeapon());
    }    
    
    public List<List<Weapon>> getWeaponTypeList(){
        return weaponTypeList;
    }

    public List<Weapon> getWeapons(){        
        return equipedWeapons;
    }

    
}
