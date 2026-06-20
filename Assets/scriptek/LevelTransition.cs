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

    public void ChangeLevel(Vector3 targetPosition)
    {
        StartCoroutine(Transition(targetPosition));
    }

    private IEnumerator Transition(Vector3 targetPos)
    {
        // fade out (fekete képernyő)
        yield return FadeManager.Instance.FadeOut();

        // “loading idő” (itt van elrejtve a teleport)
        yield return new WaitForSeconds(loadDelay);

        // teleport
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = targetPos;

        // fizika reset
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;

        // fade vissza
        yield return FadeManager.Instance.FadeIn();
    }
}