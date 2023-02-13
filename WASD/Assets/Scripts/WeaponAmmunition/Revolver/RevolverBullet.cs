using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RevolverBullet : Bullet
{
    protected int life;
    protected void TestIfLifeIs0(int life)
    {
        if(life <= 0)
        {
            Destroy(gameObject);
            return;
        }        
    }

    protected void HandleEnemyCollision(Collision2D collision, Revolver revolver)
    {
        if (collision.gameObject.tag == "Enemy")
        {     
            life--;  
            TestIfLifeIs0(life);                          
            DamageEnemies(collision, revolver);                       
            ReflectBullet(collision, revolver);
        }
    }

    protected void HandleObjectCollision(Collision2D collision, Revolver revolver)
    {
        if (collision.gameObject.tag == "Object")
        {
            life--;
            TestIfLifeIs0(life);            
            ReflectBullet(collision, revolver);
        }
    }

    protected void ReflectBullet(Collision2D collision, Revolver revolver)
    {
        if(collision.contacts.Length > 0){
            Vector2 inDirection = revolver.BulletPrefab.GetComponent<Rigidbody2D>().velocity;
            Vector2 inNormal = collision.contacts[0].normal;
            Vector2 newReflectedBulletVelocity = Vector2.Reflect(inNormal, inDirection);
            gameObject.GetComponent<Rigidbody2D>().AddForce(newReflectedBulletVelocity * revolver.FireForce, ForceMode2D.Impulse);
        }        
    }

    protected void DamageEnemies(Collision2D collision, Weapon revolver){

        Enemy[] enemies = collision.gameObject.GetComponents<Enemy>();            

            foreach(Enemy enemy in enemies){
                enemy.DamageEnemy(revolver.GetDamage());
            }            
    }
   
}
