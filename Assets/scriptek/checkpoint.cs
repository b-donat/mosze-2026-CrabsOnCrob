using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite inactiveSprite;
    public Sprite activeSprite;

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        if (inactiveSprite != null)
        {
            sr.sprite = inactiveSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RespawnManager.Instance.SetCheckpoint(this);
        }
    }

    public void Activate()
    {
        if (activeSprite != null)
        {
            sr.sprite = activeSprite;
        }
    }

    public void Deactivate()
    {
        if (inactiveSprite != null)
        {
            sr.sprite = inactiveSprite;
        }
    }
}