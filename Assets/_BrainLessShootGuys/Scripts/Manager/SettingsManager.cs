using BaseTemplate.Behaviours;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoSingleton<SettingsManager>
{
    public TMP_Dropdown resolutionDropdown;
    public Toggle vSyncToggle;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        LoadSettings();
    }

    private void LoadSettings()
    {
        SaveManager.Instance.LoadData();
        SetResolutionDropdown();
        vSyncToggle.isOn = SaveManager.Instance.gameSettings.isVSyncEnabled;

        masterSlider.value = SaveManager.Instance.gameSettings.masterVolume;
        musicSlider.value = SaveManager.Instance.gameSettings.musicVolume;
        sfxSlider.value = SaveManager.Instance.gameSettings.sfxVolume;
    }

    private void SetResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();

        Resolution[] resolutions = Screen.resolutions;
        var options = new System.Collections.Generic.List<string>();

        foreach (var res in resolutions)
        {
            options.Add(res.width + " x " + res.height);
        }

        resolutionDropdown.AddOptions(options);

        int currentResolutionIndex = options.IndexOf(SaveManager.Instance.gameSettings.screenWidth + " x " + SaveManager.Instance.gameSettings.screenHeight);
        resolutionDropdown.value = currentResolutionIndex;
    }

    public void SaveSettings()
    {
        string selectedResolution = resolutionDropdown.options[resolutionDropdown.value].text;
        string[] resolutionParts = selectedResolution.Split('x');

        int width = int.Parse(resolutionParts[0].Trim());
        int height = int.Parse(resolutionParts[1].Trim());

        SaveManager.Instance.gameSettings.screenWidth = width;
        SaveManager.Instance.gameSettings.screenHeight = height;
        SaveManager.Instance.gameSettings.isVSyncEnabled = vSyncToggle.isOn;

        Screen.SetResolution(width, height, Screen.fullScreen);
        QualitySettings.vSyncCount = vSyncToggle.isOn ? 1 : 0;

        SaveManager.Instance.gameSettings.masterVolume = masterSlider.value;
        SaveManager.Instance.gameSettings.musicVolume = musicSlider.value;
        SaveManager.Instance.gameSettings.sfxVolume = sfxSlider.value;

        SaveManager.Instance.SaveData();
        Debug.Log("Tous les paramètres (graphismes + audio) ont été sauvegardés !");
    }

    public void ResetSettings()
    {
        int defaultWidth = 1920;
        int defaultHeight = 1080;
        bool defaultVSync = true;

        SaveManager.Instance.gameSettings.screenWidth = defaultWidth;
        SaveManager.Instance.gameSettings.screenHeight = defaultHeight;
        SaveManager.Instance.gameSettings.isVSyncEnabled = defaultVSync;

        SetResolutionDropdown();
        vSyncToggle.isOn = defaultVSync;

        Screen.SetResolution(defaultWidth, defaultHeight, Screen.fullScreen);
        QualitySettings.vSyncCount = defaultVSync ? 1 : 0;

        masterSlider.value = 1.0f;
        musicSlider.value = 1.0f;
        sfxSlider.value = 1.0f;

        SaveManager.Instance.gameSettings.masterVolume = masterSlider.value;
        SaveManager.Instance.gameSettings.musicVolume = musicSlider.value;
        SaveManager.Instance.gameSettings.sfxVolume = sfxSlider.value;

        SaveManager.Instance.SaveData();
        Debug.Log("Tous les paramètres (graphismes + audio) ont été réinitialisés !");
    }
}
