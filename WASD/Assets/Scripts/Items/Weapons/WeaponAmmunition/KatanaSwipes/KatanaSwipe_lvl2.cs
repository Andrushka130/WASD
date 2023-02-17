using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaSwipe_lvl2 : KatanaSwipe
{
    private Katana_lvl2 katana;

    private void Start()
    {
        katana = GameObject.Find("Weapon").GetComponent<Katana_lvl2>();
        IgnorePhysicsOfPlayerAndAttacks();
    }   

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        HandleEnemyCollision(collision, katana);
    }
}
