using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;

    [Header("Checks")]
    public Transform groundCheck;
    public Transform wallCheck;

    public float groundCheckDistance = 0.2f;
    public float wallCheckDistance = 0.2f;

    public LayerMask groundLayer;

    private Rigidbody2D rb;

    private bool movingRight = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bool groundAhead = Physics2D.Raycast(
            groundCheck.position,
            Vector2.down,
            groundCheckDistance,
            groundLayer
        );

        bool wallAhead = Physics2D.Raycast(
            wallCheck.position,
            movingRight ? Vector2.right : Vector2.left,
            wallCheckDistance,
            groundLayer
        );

        if (!groundAhead || wallAhead)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        float direction = movingRight ? 1f : -1f;

        rb.linearVelocity = new Vector2(
            direction * moveSpeed,
            rb.linearVelocity.y
        );
    }

    void Flip()
    {
        movingRight = !movingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }


    //Debugra
    private void OnDrawGizmos()
{
    if (groundCheck != null)
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(
            groundCheck.position,
            groundCheck.position + Vector3.down * groundCheckDistance
        );
    }

    if (wallCheck != null)
    {
        Gizmos.color = Color.red;

        Vector3 dir =
            movingRight ? Vector3.right : Vector3.left;

        Gizmos.DrawLine(
            wallCheck.position,
            wallCheck.position + dir * wallCheckDistance
        );
    }
}
}

