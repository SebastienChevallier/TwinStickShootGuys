using TMPro;
using UnityEngine;

public class UIKillCount : MonoBehaviour
{
    private GameManager gameManager;
    public PlayerNumber playerNumber;
    public TMP_Text scoreText;

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = gameManager._Player.playerScore.ToString() + " kills";
    }
}
