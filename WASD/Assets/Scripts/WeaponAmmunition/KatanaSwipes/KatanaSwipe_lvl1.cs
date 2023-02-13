using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaSwipe_lvl1 : KatanaSwipe
{
    private Katana_lvl1 katana;

    private void Start()
    {
        katana = GameObject.Find("Weapon").GetComponent<Katana_lvl1>();
        IgnorePhysicsOfPlayerAndAttacks();
    }    

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        HandleEnemyCollision(collision, katana);        
    }
}
