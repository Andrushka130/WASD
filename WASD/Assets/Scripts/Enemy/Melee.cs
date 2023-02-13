using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Enemy
{

    public float attackDelay = 1f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float attackRadius = 7f;
    [SerializeField] private float maxHealth = 5f;
    [SerializeField] private float damage = 1f;
    [SerializeField] private float attackFrequency, maxAttackFrequency = 0.5f;
    [SerializeField] private float attackCooldown, maxAttackCooldown = 0.5f;
    [SerializeField] private float speedScaling = 1.1f;
    [SerializeField] private float dmgScaling = 1.1f;
    [SerializeField] private float healthScaling = 1.1f;

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

        if (directionToPlayer.magnitude > attackRadius - 0.5f)
        {
            movement = directionToPlayer.normalized * speed;
        }
        else
        {
            movement = Vector2.zero;
        }

        Body.MovePosition((Vector2)transform.position + movement * Time.fixedDeltaTime);
    }

    void Attack(Collision2D collision)
    {
        Debug.Log("Hit Player!");
        
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().DamagePlayer(damage);
            collision.gameObject.GetComponent<PlayerHealthManager>().UpdateHealth();
        }
    }

     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && this.attackCooldown == this.maxAttackCooldown)
        {
            Attack(collision);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (this.attackFrequency > 0)
            {
                this.attackFrequency -= Time.deltaTime;
            }
            else
            {
                Attack(collision);
                this.attackFrequency = this.maxAttackFrequency;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.attackFrequency = this.maxAttackFrequency;
        }
    }

    public void UpdateStats()
    {
        float currentScale = GameObject.FindWithTag("SpawnManager").GetComponent<SpawnManager>().waveCounter;

        if(currentScale > 0f)
        {
            this.speed = speed * (currentScale * speedScaling);
            this.maxHealth = maxHealth * (currentScale * healthScaling);
            this.damage = damage * (currentScale * dmgScaling);
        }
        
    }
}
