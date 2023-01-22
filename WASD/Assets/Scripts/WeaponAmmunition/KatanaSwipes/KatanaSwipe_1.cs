using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaSwipe_1 : MonoBehaviour
{
    private Katana_lvl1 katana;

    private void Start()
    {
        katana = GameObject.Find("Weapon").GetComponent<Katana_lvl1>();
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
            collision.gameObject.GetComponent<Enemy>().DamageEnemy(katana.GetDamage());
        }      

        
    }
}
