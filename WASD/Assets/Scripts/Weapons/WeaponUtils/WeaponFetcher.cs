using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class WeaponFetcher : MonoBehaviour
{        
    private Transform parent;    
    private GameObject weapon;    
    
    void Awake(){
        weapon = GameObject.Find("Weapon");
    }

    public List<List<Weapon>> FillWeaponTypeListFromWeaponStorage (){           
            
            parent = gameObject.transform;

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
        Weapon starterWeapon;
        starterWeapon = weapon.GetComponent<Weapon>();
        return starterWeapon;
    }
    
}
