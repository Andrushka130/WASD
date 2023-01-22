using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{    
    private Hacking hacking;    

    private void Start()
    {
        hacking = GameObject.Find("Weapon").GetComponent<Hacking>();
        ignorePhysicsOfPlayerAndAttacks();
    }

    private void ignorePhysicsOfPlayerAndAttacks()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        Physics2D.IgnoreLayerCollision(7, 7);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {                 

        if(collision.gameObject.tag == "Enemy")
        {
            
            collision.gameObject.GetComponent<Enemy>().DamageEnemy(hacking.GetDamage());            
            Destroy(gameObject);
        }        

        if (collision.gameObject.tag == "Object")
        {            
            Destroy(gameObject);
        }        

    }
    
}
