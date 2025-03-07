using UnityEngine;
using UnityEngine.InputSystem;

public class UiMenuPanel : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private InputSystem_Actions inputActions;
    private bool isPaused = false;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.UI.Pause.performed += ctx => TogglePause();
    }

    private void OnEnable()
    {
        inputActions.UI.Enable();
    }

    private void OnDisable()
    {
        inputActions.UI.Disable();
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenuUI.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void SaveQuitGame()
    {
        Debug.Log("Saving and quitting...");

        PlayerMovement player = FindObjectOfType<PlayerMovement>();

        if (player == null)
        {
            Debug.LogError("Player not found! Unable to save game.");
            return;
        }

        PlayerProgression progression = player.GetComponent<PlayerProgression>();

        if (progression == null)
        {
            Debug.LogError("PlayerProgression component not found on Player!");
            return;
        }

        SaveManager.Instance.gameSettings.health = player._stats._CurrentHealth;
        SaveManager.Instance.gameSettings.XP = progression.progress;
        SaveManager.Instance.gameSettings.level = progression.level;

        if (GameManager.Instance != null)
        {
            SaveManager.Instance.gameSettings.kills = GameManager.Instance._Player.playerScore;
        }
        else
        {
            Debug.LogWarning("GameManager or Player reference is null. Kills not saved.");
        }

        SaveManager.Instance.SaveData();

        Application.Quit();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
