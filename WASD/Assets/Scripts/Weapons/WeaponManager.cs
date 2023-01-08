using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{    
    private Weapon[] weapons;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {        
        weapons = gameObject.GetComponents<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {        
        foreach(var weapon in weapons)
        {
            weapon.attack();
        }
    }
}
