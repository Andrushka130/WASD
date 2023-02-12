using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponInventory
{    
    private static List<List<Weapon>> weaponTypeList = new List<List<Weapon>>();
    private WeaponFetcher fetcher;
    private static List<Weapon> equipedWeapons = new List<Weapon>(); 
    private static WeaponInventory instance = new WeaponInventory();   

    private WeaponInventory(){
        fetcher = GameObject.Find("WeaponStorage").GetComponent<WeaponFetcher>();
        weaponTypeList = fetcher.FillWeaponTypeListFromWeaponStorage();        
        equipedWeapons.Add(fetcher.FillWeaponListWithStartingWeapon());
    }       
    
    public static WeaponInventory GetInstance(){
        return instance;
    }

    public List<List<Weapon>> GetWeaponTypeList(){
        return weaponTypeList;
    }

    public List<Weapon> GetWeapons(){      
        return equipedWeapons;
    }
    
}
