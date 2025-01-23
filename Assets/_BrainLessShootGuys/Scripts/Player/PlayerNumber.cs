using UnityEngine;

public class PlayerNumber : MonoBehaviour
{
    public int number;

    void Start()
    {
        PlayerMovement[] players = FindObjectsOfType<PlayerMovement>();
        number = players.Length;
    }
}
