using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class WeaponFetcher 
{    
    private GameObject weaponStorage;
    private Transform parent;    
    private GameObject weapon;    
    
    public List<List<Weapon>> fillWeaponTypeListFromWeaponStorage (){

            weaponStorage = GameObject.Find("WeaponStorage");
            
            parent = weaponStorage.transform;

            List<Weapon> weaponList = new List<Weapon>();

            Weapon[] weaponArray;

            List<List<Weapon>> weaponTypeList = new List<List<Weapon>>();

            foreach(Transform child in parent){                                
                weaponArray = child.GetComponents<Weapon>();
                weaponList = weaponArray.ToList();
                weaponTypeList.Add(weaponList);
            } 

            return weaponTypeList;
    }

    private Weapon[] fillWeaponsArray(){
        Weapon[] weapons;
        weapons = GameObject.Find("Weapon").GetComponents<Weapon>();
        return weapons;
    }

    public Weapon fillWeaponListWithStartingWeapon(){
        
        weapon = GameObject.Find("Weapon");
        Weapon starterWeapon;
        starterWeapon = weapon.GetComponent<Weapon>();
        return starterWeapon;
    }

    public bool test(object someObject){
        
        return false;
    }
}
