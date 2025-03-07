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
        SaveManager.Instance.loadSave = false;
        SceneManager.LoadScene(1);
    }

    public void ContinueGame()
    {
        Debug.Log("Play save");

        SaveManager.Instance.loadSave = true;
        SaveManager.Instance.LoadData();

        if (SaveManager.Instance.gameSettings != null)
        {
            Debug.Log($"Chargement de la sauvegarde : Niveau {SaveManager.Instance.gameSettings.level}, XP {SaveManager.Instance.gameSettings.XP}, Santé {SaveManager.Instance.gameSettings.health}, Kills {SaveManager.Instance.gameSettings.kills}");
        }
        else
        {
            Debug.LogWarning("Aucune sauvegarde trouvée !");
        }

        SceneManager.LoadScene(1);
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
