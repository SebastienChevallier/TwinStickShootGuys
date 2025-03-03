using BaseTemplate.Behaviours;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoSingleton<UIMenuManager>
{
    [Header("UI Objects")]
    public GameObject[] Panels;

    private void Start()
    {
        ChangePanel("Menu");
    }

    public void StartNewGame()
    {
        Debug.Log("New Game");
        SceneManager.LoadScene(1);
    }

    public void ContinueGame()
    {
        Debug.Log("Play save");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void ChangePanel(string name)
    {
        foreach (var panel in Panels)
        {
            if (panel.name == name)
            {
                panel.gameObject.SetActive(true);
            }
            else
            {
                panel.gameObject.SetActive(false);
            }
        }
    }
}
