using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Explosion : Bullet
{
    protected void HandleEnemyCollision(Collision2D collision, ProjectileLaunchSystem projectileLaunchSystem){

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().DamageEnemy(projectileLaunchSystem.GetDamage());
        }
        
    }    
}
