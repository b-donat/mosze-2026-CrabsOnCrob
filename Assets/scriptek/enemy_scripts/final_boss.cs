using UnityEngine;

public class EnemyFinalBoss : MonoBehaviour
{
    public int damage = 1;
    public float bounceForce = 10f;

    [Header("Boss Stats")]
    public int maxHp = 5;

    private int currentHp;
    private Rigidbody2D rb;
    private bool isDead = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHp = maxHp;
    }

    // Játékos nekiütközik
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            bool hitFromAbove = collision.GetContact(0).normal.y > 0.1f;

            if (hitFromAbove)
            {
                TakeDamage(collision.gameObject);
            }
            else
            {
                DamagePlayer(collision.gameObject);
            }
        }
    }

    // Fej trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        if (other.CompareTag("Player"))
        {
            TakeDamage(other.gameObject);
        }
    }

    void TakeDamage(GameObject player)
    {
        currentHp--;

        // A játékos minden találat után pattanjon vissza
        Rigidbody2D prb = player.GetComponent<Rigidbody2D>();
        if (prb != null)
        {
            prb.linearVelocity = new Vector2(prb.linearVelocity.x, bounceForce);
        }

        if (currentHp <= 0)
        {
            Die();
        }
    }

    void DamagePlayer(GameObject player)
    {
        PlayerMovement pm = player.GetComponent<PlayerMovement>();

        if (pm != null)
        {
            pm.hp -= damage;

            Vector2 dir = (player.transform.position - transform.position).normalized;
            dir.y = 0.8f;

            pm.Knockback(dir, 6f);
        }
    }

    void Die()
    {
        isDead = true;

        Destroy(gameObject);
    }
}