using UnityEngine;

public class EnemyFinalBoss : MonoBehaviour
{
    public int damage = 1;
    public float bounceForce = 10f;

    private Rigidbody2D rb;
    private bool isDead = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // a játékos sebzése ha belemegy az enemybe (BODY)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            // megnézzük felülről jött-e
            bool hitFromAbove = collision.GetContact(0).normal.y > 0.1f;


            if (hitFromAbove)
            {
                Die(collision.gameObject);
            }
            else
            {
                DamagePlayer(collision.gameObject);
            }
        }
    }

    // az  enemy elszublimálása ha eltapossák (HEAD TRIGGER)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        if (other.CompareTag("Player"))
        {
            Die(other.gameObject);
        }
    }

    void DamagePlayer(GameObject player)
    {
        PlayerMovement pm = player.GetComponent<PlayerMovement>();

        if (pm != null)
        {
            pm.hp -= damage;

            // KNOCKBACK IRÁNY
            Vector2 dir = (player.transform.position - transform.position).normalized;
            dir.y = 0.8f; // kicsit felfelé is dobja

            pm.Knockback(dir, 6f);
        }
    }

    void Die(GameObject player)
    {
        isDead = true;

        // játékos bounce
        Rigidbody2D prb = player.GetComponent<Rigidbody2D>();
        if (prb != null)
        {
            prb.linearVelocity = new Vector2(prb.linearVelocity.x, bounceForce);
        }

        // enemy eltűnik
        Destroy(gameObject);
    }
}