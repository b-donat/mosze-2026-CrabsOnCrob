using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    /*ha a player belemegy egy checkpoint tag-ű objektumba,
    akkor a respawn pontja átkerül a checkpoint-hoz*/
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TRIGGER HIT: " + other.name);
        if (other.transform.root.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.name);
            Debug.Log(other.transform.root.name);
            RespawnManager.Instance.SetRespawnPoint(transform.position);
        }
    }    
}