using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public int damage;
    public float checkRadius;
    public float attackRadius;

    public bool shouldRotate;

    public LayerMask selectPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Vector3 dir;

    private bool inChaseRange;
    private bool inAttackRange;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        Collider2D[] detectColliderArray = Physics2D.OverlapCircleAll(transform.position, checkRadius);
        foreach (Collider2D collider2D in detectColliderArray)
        {
            if (collider2D.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
            {
                inChaseRange = true;               
            }

        }
        Collider2D[] attackColliderArray = Physics2D.OverlapCircleAll(transform.position, attackRadius);
        foreach (Collider2D collider2D in attackColliderArray)
        {
            if (collider2D.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
            {
                inAttackRange = true;
            }
            else
            {
                inAttackRange = false;
            }
        }

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
            
    }

    private void FixedUpdate()
    {
        if (inChaseRange && !inAttackRange)
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
        if (inAttackRange)
        {
            rb.velocity = Vector2.zero;

            //Enemy attack to be added
        }

    }
}
