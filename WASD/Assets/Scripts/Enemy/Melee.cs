using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Enemy
{

    public float speed = 2f;
    public float checkRadius = 20f;
    public float attackRadius = 1f;

    public bool shouldRotate = false;

    private Transform target;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Vector3 dir;

    private bool inChaseRange;
    private bool inAttackRange;
    private int maxHealth = 10;

    void Start()
    {
        Collider.radius = 0.5f;
        transform.localScale = new Vector2(1.0f, 1.0f);
        target = GameObject.FindWithTag("Player").transform;
        this.currentHealth = maxHealth;
        
    }

    void FixedUpdate()
    {
        MovementPattern();
        HealthUpdate(maxHealth);
    }

    protected override void MovementPattern()
    {
        Body.gravityScale = 0;
        Collider2D[] detectColliderArray = Physics2D.OverlapCircleAll(transform.position, checkRadius);
            foreach (Collider2D collider2D in detectColliderArray)
            {
                if (collider2D.TryGetComponent<PlayerController>(out PlayerController playerController))
                {
                    inChaseRange = true;
                }

            }
        Collider2D[] attackColliderArray = Physics2D.OverlapCircleAll(transform.position, attackRadius);
            foreach (Collider2D collider2D in attackColliderArray)
            {
                if (collider2D.TryGetComponent<PlayerController>(out PlayerController playerController))
                {
                    inAttackRange = true;
                }
            else
                {
                    inAttackRange = false;
                }
            }

        dir = (Vector2)target.position - Body.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;

        if (inChaseRange && !inAttackRange)
        {
            Body.MovePosition(Body.position + movement * speed * Time.fixedDeltaTime);
        }
        if (inAttackRange)
        {
            Body.velocity = Vector2.zero;

            //Enemy attack to be added
        }

    
    }
}
