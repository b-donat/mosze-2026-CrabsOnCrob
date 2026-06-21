using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager Instance;

    private Vector3 respawnPoint;
    private Checkpoint currentCheckpoint;

    private void Awake()
    {
        Instance = this;
    }

    // Checkpoint aktiválás
    public void SetCheckpoint(Checkpoint checkpoint)
    {
        if (currentCheckpoint != null)
        {
            currentCheckpoint.Deactivate();
        }

        currentCheckpoint = checkpoint;

        currentCheckpoint.Activate();

        respawnPoint = checkpoint.transform.position;
    }

    // LevelTransition nek amikor új pájára mész ott legyen a spawnod
    public void SetRespawnPoint(Vector3 position)
    {
        respawnPoint = position;
    }

    public Vector3 GetRespawnPoint()
    {
        return respawnPoint;
    }
}