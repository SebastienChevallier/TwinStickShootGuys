using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIResolutionSettings : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Dropdown resolutionDropdown;

    private void Start()
    {
        LoadResolutionSettings();
        PopulateResolutionDropdown();
        resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
    }

    private void PopulateResolutionDropdown()
    {
        Resolution[] resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        var options = new System.Collections.Generic.List<string>();
        foreach (var res in resolutions)
        {
            options.Add(res.width + "x" + res.height);
        }
        resolutionDropdown.AddOptions(options);
    }

    public void LoadResolutionSettings()
    {
        int savedResolutionIndex = PlayerPrefs.GetInt("Resolution", 0);
        resolutionDropdown.value = savedResolutionIndex;
        ApplyResolution(savedResolutionIndex);
    }

    private void ApplyResolution(int resolutionIndex)
    {
        Resolution[] resolutions = Screen.resolutions;
        if (resolutionIndex >= 0 && resolutionIndex < resolutions.Length)
        {
            Resolution selectedResolution = resolutions[resolutionIndex];
            Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreenMode);
        }
    }

    private void OnResolutionChanged(int resolutionIndex)
    {
        PlayerPrefs.SetInt("Resolution", resolutionIndex);
        PlayerPrefs.Save();

        ApplyResolution(resolutionIndex);
    }
}
