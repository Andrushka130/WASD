using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverBullet_lvl1 : RevolverBullet
{        
    private Revolver_lvl1 revolver;

    private void Start()
    {
        revolver = GameObject.Find("Weapon").GetComponent<Revolver_lvl1>();
        life = 1;
        IgnorePhysicsOfPlayerAndAttacks();
    }   

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        HandleEnemyCollision(collision, revolver);
        HandleObjectCollision(collision, revolver);
    }
}
