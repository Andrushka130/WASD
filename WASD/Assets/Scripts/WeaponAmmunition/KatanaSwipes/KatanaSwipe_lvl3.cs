using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaSwipe_lvl3 : KatanaSwipe
{
    private Katana_lvl3 katana;

    private void Start()
    {
        katana = GameObject.Find("Weapon").GetComponent<Katana_lvl3>();
        IgnorePhysicsOfPlayerAndAttacks();
    }   

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        HandleEnemyCollision(collision, katana);
    }
}
