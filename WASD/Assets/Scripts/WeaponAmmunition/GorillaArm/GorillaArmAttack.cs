using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GorillaArmAttack : Bullet
{
    protected abstract float pushForce {get; set;}
    protected abstract Vector2 pushVector {get; set;}
    protected abstract int pushVectorAmplification{get; set;}

    protected void HandleEnemyCollision(Collision2D collision, GorillaArms gorillaArm){
        if (collision.gameObject.tag == "Enemy")
        {
            pushVector = transform.right * pushVectorAmplification;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(pushVector * pushForce);
            collision.gameObject.GetComponent<Enemy>().DamageEnemy(gorillaArm.GetDamage());
        }
    }
}
