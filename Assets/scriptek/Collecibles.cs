using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int value = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(value);

            Destroy(gameObject);
        }
    }
}