using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WeaponInventory inv = WeaponInventory.GetInstance();
        List<Weapon> list = inv.GetWeapons();
        foreach(Weapon weapon in list){
            Debug.Log(weapon.Name);
        }

        inv.GetWeapons().Add(GameObject.Find("Revolver").GetComponent<Revolver_lvl1>());

        Debug.Log("Second loop");
        foreach(Weapon weapon in list){
            Debug.Log(weapon.Name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
