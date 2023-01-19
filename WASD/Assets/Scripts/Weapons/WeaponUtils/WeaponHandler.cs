using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler 
{
    private WeaponStorage storage;
    private int maximumSizeOfWeaponInventory = 4;   
    private GameObject weapon;

    public bool InsertNewWeapon(Weapon newWeapon){

        if(CheckWeaponListSize()){            
            InsertWeaponScriptToGameobject(newWeapon);
            InsertNewWeaponIntoWeaponList(newWeapon);     
            return true;      
        }       
        return false;
    }

    private void InsertNewWeaponIntoWeaponList(Weapon boughtWeapon){
        
            DeleteFormerUpgradeLevelFromList(boughtWeapon); 
            storage.GetWeapons().Add(boughtWeapon);     
                           
    }

    private void DeleteFormerUpgradeLevelFromList(Weapon boughtWeapon){

        storage = GameObject.Find("WeaponStorage").GetComponent<WeaponStorage>();        

        for(int i = 0; i < storage.GetWeapons().Count; i++){
            Weapon currentWeapon = storage.GetWeapons()[i];
            if(IsWeaponLevelAndNameEqual(currentWeapon, boughtWeapon)){
                storage.GetWeapons().Remove(storage.GetWeapons()[i]);
            }
        }
    }

    private void InsertWeaponScriptToGameobject(Weapon boughtWeapon){  

            DeleteFormerUpgradeLevelInGameObject(boughtWeapon);
            weapon = GameObject.Find("Weapon");
            var typeOfWeapon = boughtWeapon.GetType();
            weapon.AddComponent(typeOfWeapon);
                   
    }

    private void DeleteFormerUpgradeLevelInGameObject(Weapon boughtWeapon){
        
        weapon = GameObject.Find("Weapon");       

        Weapon[] currentlyEquipedWeapons =  weapon.GetComponents<Weapon>();
        foreach(var equipedWeapon in currentlyEquipedWeapons){
            if(IsWeaponLevelAndNameEqual(equipedWeapon, boughtWeapon)){
                equipedWeapon.DestroyScript();
            }
        }        
    }    

    private bool CheckWeaponListSize(){

        storage = GameObject.Find("WeaponStorage").GetComponent<WeaponStorage>();
        if(storage.GetWeapons().Count == maximumSizeOfWeaponInventory){
            return false;
        }   
        return true;
    }
   
   private bool IsWeaponLevelAndNameEqual(Weapon oldWeapon, Weapon newWeapon){

        if(oldWeapon.WeaponLevel < newWeapon.WeaponLevel && oldWeapon.Name == newWeapon.Name){
            return true;
        }
        return false;
   }
}
