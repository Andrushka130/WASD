using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaArmAttack_lvl3 : GorillaArmAttack
{   
    private GorillaArms_lvl3 gorillaArm;
    protected override Vector2 pushVector {get; set;}
    protected override int pushVectorAmplification{get; set;}
    protected override float pushForce {get; set;}

    private void Start()
    {
        gorillaArm = GameObject.Find("Weapon").GetComponent<GorillaArms_lvl3>();        
        pushForce = 120f;
        pushVector = new Vector2();
        pushVectorAmplification = 120;
        IgnorePhysicsOfPlayerAndAttacks();
    }    

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        HandleEnemyCollision(collision, gorillaArm);
    }
}
