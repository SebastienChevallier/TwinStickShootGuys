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
        Debug.Log("Save Game");
        Application.Quit();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
