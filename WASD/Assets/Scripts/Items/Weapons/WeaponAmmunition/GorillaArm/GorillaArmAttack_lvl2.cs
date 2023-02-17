using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaArmAttack_lvl2 : GorillaArmAttack
{    
    private GorillaArms_lvl2 gorillaArm;
    protected override Vector2 pushVector {get; set;}
    protected override int pushVectorAmplification{get; set;}
    protected override float pushForce {get; set;}

    private void Start()
    {
        gorillaArm = GameObject.Find("Weapon").GetComponent<GorillaArms_lvl2>();        
        pushForce = 120f;
        pushVector = new Vector2();
        pushVectorAmplification = 100;
        IgnorePhysicsOfPlayerAndAttacks();
    }   

    protected override void OnCollisionEnter2D(Collision2D collision)
    {        
        HandleEnemyCollision(collision, gorillaArm);
    }
}
