using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : Enemy
{
    public GameObject currentProjectile;
    public Transform firePoint;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float attackRadius = 7f;
    [SerializeField] private float attackDelay = 1f;
    [SerializeField] private float projectileSpeed = 2f;
    [SerializeField] private float maxHealth = 5f;
    [SerializeField] private float speedScaling = 1.1f;
    [SerializeField] private float healthScaling = 1.1f;
    [SerializeField] private float attackSpeedScaling = 1.1f;

    private Transform target;
    private Vector2 movement;
    private Vector2 dir;
    private float timeSinceLastAttack;
    private Vector2 directionToPlayer;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        this.currentHealth = maxHealth;
        UpdateStats();
        
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
                Attack();
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

    public void UpdateStats()
    {
        float currentScale = GameObject.FindWithTag("SpawnManager").GetComponent<SpawnManager>().waveCounter;

        if(currentScale > 0f)
        {
            this.speed = speed * (currentScale * speedScaling);
            this.maxHealth = maxHealth * (currentScale * healthScaling);
            this.attackDelay = attackDelay * (currentScale * attackSpeedScaling);
        }
        
    }
}
