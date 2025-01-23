using UnityEngine;

public class NumberOfPlayerSetter : MonoBehaviour
{
    public void SetNumberOfPlayer(int numberOfPlayers)
    {
        GameModManager.Instance.numberOfPlayers = numberOfPlayers;
    }
}
