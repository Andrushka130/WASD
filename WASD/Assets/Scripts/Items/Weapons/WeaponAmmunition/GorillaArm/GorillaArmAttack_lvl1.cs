using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaArmAttack_lvl1 : GorillaArmAttack
{
    private GorillaArms_lvl1 gorillaArm;
    protected override Vector2 pushVector {get; set;}
    protected override int pushVectorAmplification{get; set;}
    protected override float pushForce {get; set;}

    private void Start()
    {
        gorillaArm = GameObject.Find("Weapon").GetComponent<GorillaArms_lvl1>();
        pushForce = 120f;
        pushVector = new Vector2();
        pushVectorAmplification = 80;
        IgnorePhysicsOfPlayerAndAttacks();
    }    

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        HandleEnemyCollision(collision, gorillaArm);
    }


}
