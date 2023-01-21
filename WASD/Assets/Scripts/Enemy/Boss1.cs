using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Enemy
{

    public float speed = 1f;
    public float checkRadius = 30f;
    public float attackRadius = 7f;
    public float attackDelay = 1f;
    public float projectileSpeed = 2f;
    public float barrageAmount = 5f;
    public float barrageTimer = 0.1f;
    public int maxHealth = 5;
    public GameObject currentProjectile;
    public Transform firePoint;

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

        if (directionToPlayer.magnitude >= attackRadius)
        {
            movement = directionToPlayer.normalized * speed;
        }
        
        else if(directionToPlayer.magnitude < attackRadius)
        {
            timeSinceLastAttack += Time.deltaTime;
            if(timeSinceLastAttack >= attackDelay)
            {
                timeSinceLastAttack = 0f;

                for(int i = 0; i <= barrageAmount; i++)
                {
                    Attack();
                    
                }
            }

            if(directionToPlayer.magnitude < attackRadius - 0.3f && directionToPlayer.magnitude >= attackRadius - 2f)
            {
                movement = Vector2.zero;
            }

            else if(directionToPlayer.magnitude < attackRadius - 2f)
            {
                movement = directionToPlayer.normalized * speed * (-1f);
            }
        }

        Body.MovePosition((Vector2)transform.position + movement * Time.fixedDeltaTime);
    }

    void Attack()
    {
        target = GameObject.FindWithTag("Player").transform;
        GameObject projectile = Instantiate(currentProjectile, (Vector2)firePoint.position + (Vector2)(target.position - transform.position).normalized * 1.5f, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce((Vector2)(target.position - transform.position).normalized * projectileSpeed, ForceMode2D.Impulse);
    }
}
