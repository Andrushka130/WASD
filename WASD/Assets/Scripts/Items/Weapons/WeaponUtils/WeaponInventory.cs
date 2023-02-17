using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{    
    private List<List<Weapon>> weaponTypeList = new List<List<Weapon>>();
    private WeaponFetcher fetcher;
    private List<Weapon> equipedWeapons = new List<Weapon>(); 
    private static WeaponInventory instance;

    void Awake()
    {
        fetcher = GameObject.Find("WeaponStorage").GetComponent<WeaponFetcher>();   
        weaponTypeList = fetcher.FillWeaponTypeListFromWeaponStorage();        
        equipedWeapons.Add(fetcher.FillWeaponListWithStartingWeapon());
    }  
   
    public static WeaponInventory GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<WeaponInventory>();
            if(instance == null)
            {
                instance = new GameObject().AddComponent<WeaponInventory>();
            }
        }
        return instance;
    }

    public List<List<Weapon>> GetWeaponTypeList()
    {
        return weaponTypeList;
    }

    public List<Weapon> GetWeapons()
    {      
        return equipedWeapons;
    }
}
