using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackingBullet_lvl3 : HackingBullet
{    
    private Hacking_lvl3 hacking;

    private void Start()
    {
        hacking = GameObject.Find("Weapon").GetComponent<Hacking_lvl3>();
        IgnorePhysicsOfPlayerAndAttacks();
    }    

    protected override void OnCollisionEnter2D(Collision2D collision)
    {        
        OnEnemyCollision(collision, hacking);
        OnObjectCollision(collision);
    }
}
