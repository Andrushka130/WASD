using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_lvl2 : Explosion
{    
    private ProjectileLaunchSystem_lvl2 projectileLaunchSystem;

    private void Start()
    {
        projectileLaunchSystem = GameObject.Find("Weapon").GetComponent<ProjectileLaunchSystem_lvl2>();        
        IgnorePhysicsOfPlayerAndAttacks();
    }    

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        HandleEnemyCollision(collision, projectileLaunchSystem);
    }
}
