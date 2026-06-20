using UnityEngine;

public class LevelTransitionTrigger : MonoBehaviour
{
    public Transform targetSpawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            LevelTransition.Instance.ChangeLevel(
                targetSpawnPoint.position
            );
        }
    }
}