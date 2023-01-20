using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler 
{
    private WeaponInventory inventory = WeaponInventory.getInstance();
    private int maximumSizeOfWeaponInventory = 6;   
    private GameObject weapon;
   
    public bool InserNewWeapon(Weapon newWeapon){

        if(CheckWeaponListSize()){            
            InsertWeaponScriptToGameobject(newWeapon);
            InsertNewWeaponIntoWeaponList(newWeapon);     
            return true;      
        }       
        return false;
    }

    private void InsertNewWeaponIntoWeaponList(Weapon boughtWeapon){
        
            DeleteFormerUpgradeLevelFromList(boughtWeapon); 
            inventory.GetWeapons().Add(boughtWeapon);                                
    }

    private void DeleteFormerUpgradeLevelFromList(Weapon boughtWeapon){             

        for(int i = 0; i < inventory.GetWeapons().Count; i++){
            Weapon currentWeapon = inventory.GetWeapons()[i];
            if(IsWeaponLevelAndNameEqual(currentWeapon, boughtWeapon)){
                inventory.GetWeapons().Remove(inventory.GetWeapons()[i]);
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
        
        if(inventory.GetWeapons().Count == maximumSizeOfWeaponInventory){
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
