using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private WeaponClass[] weapons;
    private Hacking hack;    
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        weapons = gameObject.GetComponents<WeaponClass>();
        hack = (Hacking)GameObject.Find("Weapon").GetComponent("Hacking");
        
    }

    // Update is called once per frame
    void Update()
    {
        hack.automaticShooting();
    }
}
