using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverBullet_lvl3 : RevolverBullet
{     
    private Revolver_lvl3 revolver;      

    private void Start()
    {
        revolver = GameObject.Find("Weapon").GetComponent<Revolver_lvl3>();       
        life = 5;
        IgnorePhysicsOfPlayerAndAttacks();        
    }    

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        HandleEnemyCollision(collision, revolver);
        HandleObjectCollision(collision, revolver);

    }    
}
