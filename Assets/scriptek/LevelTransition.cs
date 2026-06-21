using System.Collections;
using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    public static LevelTransition Instance;

    public float loadDelay = 0.5f;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeLevel(Vector3 targetPosition, Vector3 newSpawnPoint)
    {
        StartCoroutine(Transition(targetPosition, newSpawnPoint));
    }

    private IEnumerator Transition(Vector3 targetPos, Vector3 newSpawn)
    {
        yield return FadeManager.Instance.FadeOut();

        yield return new WaitForSeconds(loadDelay);

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        player.transform.position = targetPos;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;

        RespawnManager.Instance.SetRespawnPoint(newSpawn);

        yield return FadeManager.Instance.FadeIn();
    }
}