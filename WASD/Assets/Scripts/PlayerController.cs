using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Weapon weapon;

    public float timer;
    public float cooldown = 1f;
    
    Vector2 moveDirection;
    Vector2 mousePosition;

    // Update is called once per frame
    void Update()
    {
        weapon = GameObject.Find("Weapon").GetComponent<Weapon>();
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        timer += Time.deltaTime;
        if(timer > cooldown)
        {
            weapon.Fire();
            timer = 0;
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
}
