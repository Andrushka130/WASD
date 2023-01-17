using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WeaponStorage
{
    private static List<List<Weapon>> weaponTypeList = new List<List<Weapon>>();
    private WeaponFetcher fetcher;
    private static Weapon[] weapons;   
    private GameObject weaponStorage;
    private Transform parent;     
    public WeaponStorage()
    {        
        fetcher = new WeaponFetcher();
        weaponStorage = GameObject.Find("WeaponStorage");
        weaponTypeList = fetcher.fillWeaponTypeListFromWeaponStorage();
    }    
    
    public List<List<Weapon>> getWeaponTypeList(){
        return weaponTypeList;
    }

    public Weapon[] getWeaponsArray(){
        return weapons;
    }

    
}
