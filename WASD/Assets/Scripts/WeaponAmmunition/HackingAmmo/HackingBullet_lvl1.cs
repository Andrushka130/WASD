using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackingBullet_lvl1 : HackingBullet
{    
    private Hacking_lvl1 hacking;    

    private void Start()
    {
        hacking = GameObject.Find("Weapon").GetComponent<Hacking_lvl1>();
        IgnorePhysicsOfPlayerAndAttacks();
    }   

    protected override void OnCollisionEnter2D(Collision2D collision)
    {         
        OnEnemyCollision(collision, hacking); 
        OnObjectCollision(collision);   
    }    
    
}
