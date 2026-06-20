using UnityEngine;
using TMPro;

public class HPUI : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public PlayerMovement player;

    void Update()
    {
        hpText.text = "HP: " + player.hp;
    }
}