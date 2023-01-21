using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Enemy
{

    public float speed = 1f;
    public float checkRadius = 30f;
    public float attackRadius = 7f;
    public float attackDelay = 1f;
    public int maxHealth = 5;
    public int damage = 1;

    private Transform target;
    private Vector2 movement;
    private Vector2 dir;
    private float timeSinceLastAttack;
    private Vector2 directionToPlayer;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        this.currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        HealthUpdate(maxHealth);
        MovementPattern();
    }

    protected override void MovementPattern()
    {

        Vector2 directionToPlayer = target.position - transform.position;

        if (directionToPlayer.magnitude > attackRadius - 0.5f)
        {
            movement = directionToPlayer.normalized * speed;
        }
        else if(directionToPlayer.magnitude <= attackRadius - 0.5f)
            {
                movement = Vector2.zero;
            }

        if(directionToPlayer.magnitude <= attackRadius)
        {
            timeSinceLastAttack += Time.deltaTime;
            if(timeSinceLastAttack >= attackDelay)
            {
                timeSinceLastAttack = 0f;
                Attack();
            }
        }

        Body.MovePosition((Vector2)transform.position + movement * Time.fixedDeltaTime);
    }

    void Attack()
    {
        target = GameObject.FindWithTag("Player").transform;
        target.GetComponent<PlayerController>().TakeDamage(damage);
    }
}
