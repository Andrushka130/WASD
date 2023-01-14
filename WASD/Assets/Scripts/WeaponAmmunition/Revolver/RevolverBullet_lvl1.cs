using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverBullet_lvl1 : MonoBehaviour
{    
    public float fadeOutTime = 0.25f;
    private float bulletDamage;
    private Revolver_lvl1 revolver;


    private void Start()
    {
        revolver = GameObject.Find("Weapon").GetComponent<Revolver_lvl1>();
        bulletDamage = revolver.Dmg;
        ignorePhysicsOfPlayerAndAttacks();
    }

    private void ignorePhysicsOfPlayerAndAttacks()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        Physics2D.IgnoreLayerCollision(7, 7);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {            
            collision.gameObject.GetComponent<EnemyHealthScript>().DamageEnemy(bulletDamage);            
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Object")
        {                       
            Destroy(gameObject);
        }

    }
}
