using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{

    #region Singleton

    public static WeaponInventory instance;

    void Awake ()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of WeaponInventory found!");
            return;
        }
        instance = this;
    }
    
    #endregion

    public int space = 20;

    public List<Weapon> weapons = new List<Weapon>();

    public bool Add (Weapon weapon)
    {
        if(weapons.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }

        weapons.Add(weapon);
        return true;
    }

    public void Remove (Weapon weapon)
    {
        weapons.Remove(weapon);
    }

}
