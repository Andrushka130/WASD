using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverBullet_lvl2 : RevolverBullet
{
    private Revolver_lvl2 revolver;       

    private void Start()
    {
        revolver = GameObject.Find("Weapon").GetComponent<Revolver_lvl2>();
        life = 2;
        IgnorePhysicsOfPlayerAndAttacks();        
    }    

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        HandleEnemyCollision(collision, revolver);
        HandleObjectCollision(collision, revolver);
    }   

    
}
