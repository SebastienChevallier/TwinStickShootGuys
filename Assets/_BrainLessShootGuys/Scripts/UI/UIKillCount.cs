using TMPro;
using UnityEngine;
using static GameManager;

public class UIKillCount : MonoBehaviour
{
    private GameManager gameManager;
    public PlayerNumber playerNumber;
    public TMP_Text scoreText;

    void Start()
    {
        gameManager = GameManager.Instance;

        if (SaveManager.Instance.loadSave && SaveManager.Instance.gameSettings != null)
        {
            gameManager._Player.playerScore = SaveManager.Instance.gameSettings.kills;
        }
        else
        {
            gameManager._Player.playerScore = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = gameManager._Player.playerScore.ToString() + " kills";
    }
}
