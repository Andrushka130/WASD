using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Weapon weapon;
    public float timer;
    public float cooldown = 1f;

    public void fire()
    {
        weapon = GameObject.Find("Weapon").GetComponent<Weapon>();

        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            weapon.Fire();
            timer = 0;
        }
    }
}
