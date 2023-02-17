using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KatanaSwipe : Bullet
{
    protected void HandleEnemyCollision(Collision2D collision, Katana katana){

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().DamageEnemy(katana.GetDamage());
        }  
        
    }
}
