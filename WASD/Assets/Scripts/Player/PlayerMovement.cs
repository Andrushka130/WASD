using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static ICharacters curChar;
    public float moveSpeed = 5f;   

    public Vector2 movementVector;

    private Rigidbody2D rb;

    private void Start()
    {
        curChar = CharactersManager.CurrentChar;
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    public void getMovementInput()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
    }

    public void movePlayer()
    {
        rb.MovePosition(rb.position + movementVector * GetMoveSpeed() * Time.fixedDeltaTime);
    }

    private float GetMoveSpeed()
    {
        Debug.Log(moveSpeed * (((float) curChar.MovementSpeedValue + 100) / 100));
        return moveSpeed * (((float) curChar.MovementSpeedValue + 100) / 100);
    }
}
