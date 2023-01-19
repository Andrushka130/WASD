using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulllet2 : MonoBehaviour
{
    
    public float fadeOutTime = 0.25f;
    private Hacking_lvl2 hacking;
    

    private void Start()
    {
        hacking = GameObject.Find("Weapon").GetComponent<Hacking_lvl2>();
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
            
            collision.gameObject.GetComponent<EnemyHealthScript>().DamageEnemy(hacking.GetDamage());            
            Destroy(gameObject);
            
        }

        if (collision.gameObject.tag == "Object")
        {           
            
            Destroy(gameObject);
        }

    }
}
