using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float fadeOutTime = 0.25f;
    private float bulletDamage;
    private Hacking hacking;    

    private void Start()
    {
        hacking = GameObject.Find("Weapon").GetComponent<Hacking>();
        bulletDamage = hacking.Dmg;        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {                 

        if(collision.gameObject.tag == "Enemy")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<EnemyHealthScript>().DamageEnemy(bulletDamage);
            Destroy(effect, fadeOutTime);
            Destroy(gameObject);
        }        

        if (collision.gameObject.tag == "Object")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, fadeOutTime);
            Destroy(gameObject);
        }        

    }
    
}
