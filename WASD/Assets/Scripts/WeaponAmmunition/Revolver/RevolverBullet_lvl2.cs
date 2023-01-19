using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverBullet_lvl2 : MonoBehaviour
{
    private Revolver_lvl2 revolver;
    private int life;
    

    private void Start()
    {
        revolver = GameObject.Find("Weapon").GetComponent<Revolver_lvl2>();
        life = 1;
        IgnorePhysicsOfPlayerAndAttacks();
        
    }

    private void IgnorePhysicsOfPlayerAndAttacks()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        Physics2D.IgnoreLayerCollision(7, 7);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        handleEnemyCollision(collision);
        handleObjectCollision(collision);

    }

    private void handleEnemyCollision(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TestIfLifeIs0(life);
            life--;

            collision.gameObject.GetComponent<EnemyHealthScript>().DamageEnemy(revolver.GetDamage());

            reflectBullet(collision);
        }
    }

    private void handleObjectCollision(Collision2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            TestIfLifeIs0(life);
            life--;
            reflectBullet(collision);
        }
    }

    private void reflectBullet(Collision2D collision)
    {
        Vector2 inDirection = revolver.BulletPrefab.GetComponent<Rigidbody2D>().velocity;
        Vector2 inNormal = collision.contacts[0].normal;
        Vector2 newReflectedBulletVelocity = Vector2.Reflect(inNormal, inDirection);
        gameObject.GetComponent<Rigidbody2D>().AddForce(newReflectedBulletVelocity * revolver.FireForce, ForceMode2D.Impulse);
    }

    private void TestIfLifeIs0(int life)
    {
        if(life == 0)
        {
            Destroy(gameObject);
            return;
        }
        
    }
}
