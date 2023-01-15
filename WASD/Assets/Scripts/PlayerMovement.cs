using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;   

    public Vector2 movementVector;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    public void getMovementInput()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
    }

    public void movePlayer()
    {
        rb.MovePosition(rb.position + movementVector * moveSpeed * Time.fixedDeltaTime);
    }
}
