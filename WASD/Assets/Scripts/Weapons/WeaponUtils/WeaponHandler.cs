using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler 
{
    private WeaponStorage storage;
    private int maximumSizeOfWeaponInventory = 5;   
    private GameObject weapon;


    public void insertNewWeaponIntoWeaponList(Weapon boughtWeapon){
        if(checkWeaponListSize() == true){
            storage.getWeapons().Add(boughtWeapon);
        }        
    }

    public void deleteFormerUpgradeLevelFromList(Weapon boughtWeapon){

        foreach(Weapon weapon in storage.getWeapons()){
            if(weapon.WeaponLevel < boughtWeapon.WeaponLevel){
                storage.getWeapons().Remove(weapon);
            }
        }
    }

    public void insertWeaponScriptToGameobject(Weapon weaponToEquip){
        if(checkWeaponListSize() == true){
            weapon = GameObject.Find("Weapon");
            var typeOfWeapon = weaponToEquip.GetType();
            weapon.AddComponent(typeOfWeapon);
        }

    }

    public void deleteFormerUpgradeLevelInGameObject(Weapon boughtWeapon){

        weapon = GameObject.Find("Weapon");       

        Weapon[] currentlyEquipedWeapons =  weapon.GetComponents<Weapon>();
        foreach(var equipedWeapon in currentlyEquipedWeapons){
            if(equipedWeapon.WeaponLevel < boughtWeapon.WeaponLevel){
                equipedWeapon.DestroyScript();
            }
        }             
    }    

    private bool checkWeaponListSize(){
        if(storage.getWeapons().Count == maximumSizeOfWeaponInventory){
            return false;
        }   
        return true;
    }
   
}
