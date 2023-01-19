using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverBullet_lvl2 : MonoBehaviour
{
    public float fadeOutTime = 0.25f;
    private Revolver_lvl2 revolver;
    private int life;
    private Rigidbody2D rb;
    private Vector2 lastVelocity;

    private void Start()
    {
        revolver = GameObject.Find("Weapon").GetComponent<Revolver_lvl2>();
        rb = GetComponent<Rigidbody2D>();
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
        if (collision.gameObject.tag == "Enemy")
        {
            TestIfLifeIs0(life);
            life--;
            collision.gameObject.GetComponent<EnemyHealthScript>().DamageEnemy(revolver.GetDamage());

            Vector2 inDirection = revolver.BulletPrefab.GetComponent<Rigidbody2D>().velocity;
            Vector2 inNormal = collision.contacts[0].normal;
            Vector2 newReflectedBulletVelocity = Vector2.Reflect(inDirection, inNormal);
            gameObject.GetComponent<Rigidbody2D>().AddForce(newReflectedBulletVelocity * revolver.FireForce, ForceMode2D.Impulse);

        }

        if (collision.gameObject.tag == "Object")
        {
            TestIfLifeIs0(life);
            life--;

            Vector2 inDirection = revolver.BulletPrefab.GetComponent<Rigidbody2D>().velocity;
            Vector2 inNormal = collision.contacts[0].normal;
            Vector2 newReflectedBulletVelocity = Vector2.Reflect(inDirection, inNormal);
            gameObject.GetComponent<Rigidbody2D>().AddForce(newReflectedBulletVelocity * revolver.FireForce, ForceMode2D.Impulse);
        }

    }

    private void TestIfLifeIs0(int life)
    {
        if(life == 0)
        {
            Destroy(gameObject);
        }
    }
}
