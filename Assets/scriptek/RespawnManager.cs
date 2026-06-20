using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager Instance;

    private Vector3 respawnPoint;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetRespawnPoint(Vector3 point)
    {
        respawnPoint = point;
    }

    public Vector3 GetRespawnPoint()
    {
        return respawnPoint;
    }
}