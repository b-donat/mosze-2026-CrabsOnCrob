using UnityEngine;

public class LevelTransitionTrigger : MonoBehaviour
{
    public Transform targetSpawnPoint;      // hova teleport
    public Transform newLevelSpawnPoint;     // új checkpoint (LEVEL START)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            LevelTransition.Instance.ChangeLevel(
                targetSpawnPoint.position,
                newLevelSpawnPoint.position
            );
        }
    }
}