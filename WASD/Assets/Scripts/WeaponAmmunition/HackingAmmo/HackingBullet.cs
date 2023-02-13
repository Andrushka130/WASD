using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HackingBullet : Bullet
{
    protected void OnEnemyCollision(Collision2D collision, Weapon hacking){

        if(collision.gameObject.tag == "Enemy")
        {            
            collision.gameObject.GetComponent<Enemy>().DamageEnemy(hacking.GetDamage());            
            Destroy(gameObject);
        }  
        
    }
    protected void OnObjectCollision(Collision2D collision){

        if (collision.gameObject.tag == "Object")
        {            
            Destroy(gameObject);
        }  

    }
}
