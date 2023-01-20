using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponStorage : MonoBehaviour
{    
    private static List<List<Weapon>> weaponTypeList = new List<List<Weapon>>();
    private WeaponFetcher fetcher = new WeaponFetcher();
    private static List<Weapon> equipedWeapons = new List<Weapon>();    

    void Start(){             
        weaponTypeList = fetcher.FillWeaponTypeListFromWeaponStorage();        
        equipedWeapons.Add(fetcher.FillWeaponListWithStartingWeapon());
    }       
    
    public List<List<Weapon>> GetWeaponTypeList(){
        return weaponTypeList;
    }

    public List<Weapon> GetWeapons(){      
        return equipedWeapons;
    }
    
}
