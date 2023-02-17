using UnityEngine;

public class DropMagnet : MonoBehaviour
{
    public float speed;
    public float checkRadius;

    public LayerMask selectPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Vector3 dir;

    private bool inMagnetRange;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        Collider2D[] detectColliderArray = Physics2D.OverlapCircleAll(transform.position, checkRadius);
        foreach (Collider2D collider2D in detectColliderArray)
        {
            if (collider2D.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
            {
                inMagnetRange = true;
            }
        }

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
    }

    private void FixedUpdate()
    {
        if (inMagnetRange)
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + movement * 1/150 * speed * Time.fixedDeltaTime);
        }
    }
}