using UnityEngine;
using System.IO;
using BaseTemplate.Behaviours;

public class SaveManager : MonoSingleton<SaveManager>
{
    private string saveFilePath;
    public GameSettings gameSettings;

    private void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "gameSave.json");
        LoadData();
    }

    public void SaveData()
    {
        try
        {
            string jsonData = JsonUtility.ToJson(gameSettings, true);
            File.WriteAllText(saveFilePath, jsonData);

            Debug.Log("Données sauvegardées : " + jsonData);
            Debug.Log("Fichier de sauvegarde situé à : " + saveFilePath);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Erreur lors de la sauvegarde des données : " + e.Message);
        }
    }

    public void LoadData()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            gameSettings = JsonUtility.FromJson<GameSettings>(json);
            Debug.Log("Données chargées depuis : " + saveFilePath);
        }
        else
        {
            Debug.LogWarning("Aucune sauvegarde trouvée.");
            gameSettings = new GameSettings();
        }
    }
}
