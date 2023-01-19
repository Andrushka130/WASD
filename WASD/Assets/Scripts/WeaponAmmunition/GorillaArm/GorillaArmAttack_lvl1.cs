using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaArmAttack_lvl1 : MonoBehaviour
{
    private GorillaArms_lvl1 gorillaArm;
    private Vector2 pushVector;
    private float pushForce;

    private void Start()
    {
        gorillaArm = GameObject.Find("Weapon").GetComponent<GorillaArms_lvl1>();
        pushForce = 120f;
        ignorePhysicsOfPlayerAndAttacks();
    }
    private void ignorePhysicsOfPlayerAndAttacks()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        Physics2D.IgnoreLayerCollision(7, 7);
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit" + collision.gameObject);
        if (collision.gameObject.tag == "Enemy")
        {
            pushVector = transform.right * 80;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(pushVector * pushForce);
            collision.gameObject.GetComponent<EnemyHealthScript>().DamageEnemy(gorillaArm.GetDamage());
        }
    }


}
