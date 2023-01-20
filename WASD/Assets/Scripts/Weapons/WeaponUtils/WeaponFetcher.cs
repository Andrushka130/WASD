using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class WeaponFetcher 
{    
    private GameObject weaponStorage;
    private Transform parent;    
    private GameObject weapon;    
    
    public List<List<Weapon>> FillWeaponTypeListFromWeaponStorage (){

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

    public Weapon FillWeaponListWithStartingWeapon(){        
        weapon = GameObject.Find("Weapon");
        Weapon starterWeapon;
        starterWeapon = weapon.GetComponent<Weapon>();
        return starterWeapon;
    }
    
}
