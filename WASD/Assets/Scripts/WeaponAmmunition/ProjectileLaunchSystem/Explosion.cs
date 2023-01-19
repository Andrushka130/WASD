using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private ProjectileLaunchSystem_lvl1 projectileLaunchSystem;

    private void Start()
    {
        projectileLaunchSystem = GameObject.Find("Weapon").GetComponent<ProjectileLaunchSystem_lvl1>();
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
            collision.gameObject.GetComponent<EnemyHealthScript>().DamageEnemy(projectileLaunchSystem.GetDamage());
        }
    }
}