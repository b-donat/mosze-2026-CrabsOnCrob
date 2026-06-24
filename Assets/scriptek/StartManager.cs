using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Transform firstSpawnPoint;
    public GameObject titleScreen;

    public void StartGame()
    {
            Debug.Log("PLAY GOMB MEGNYOMVA");
        StartCoroutine(StartGameRoutine());
    }

    private IEnumerator StartGameRoutine()
    {
        // Play gomb eltüntetése
        titleScreen.SetActive(false);

        // Fade Out
        yield return FadeManager.Instance.FadeOut();

        // Játékos aktiválása
        player.SetActive(true);

        // Spawn pozíció
        player.transform.position = firstSpawnPoint.position;

        // Respawn pont beállítása
        if (RespawnManager.Instance != null)
        {
            RespawnManager.Instance.SetRespawnPoint(firstSpawnPoint.position);
        }

        // Fade In
        yield return FadeManager.Instance.FadeIn();
    }
}