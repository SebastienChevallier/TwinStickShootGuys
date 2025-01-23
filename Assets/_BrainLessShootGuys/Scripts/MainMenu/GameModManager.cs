using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModManager : MonoBehaviour
{
    private static GameModManager instance = null;
    public static GameModManager Instance => instance;

    [Range(2,4)]
    public int numberOfPlayers;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
