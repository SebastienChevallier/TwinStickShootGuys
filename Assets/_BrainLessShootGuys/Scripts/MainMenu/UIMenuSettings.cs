using UnityEngine;
using BaseTemplate.Behaviours;
using UnityEngine.UI;
public class UIMenuSettings : MonoSingleton<UIMenuSettings>
{
    [Header("Parametters")]
    public SoundSettings soundSettings;
    public UIResolutionSettings resolutionSettings;

    [Header("UI Elements")]
    public Toggle vsyncToggle;
    public Text vsyncStatusText;

    private void Start()
    {
        LoadSettings();
    }

    public void SaveSettings()
    {
        PlayerPrefs.Save();
        if (soundSettings != null)
        {
            soundSettings.LoadSettings();
        }
    }

    public void LoadSettings()
    {
        AudioListener.volume = GetVolume("Master");
        LoadVSync();
    }

    public void LoadVSync()
    {
        bool isVsyncEnabled = PlayerPrefs.GetInt("VSync", 1) == 1;
        vsyncToggle.isOn = isVsyncEnabled;
        ApplyVsync(isVsyncEnabled);
    }

    public void ResetSettings()
    {
        SetVolume("Master", 1f);
        SetVolume("Music", 1f);
        SetVolume("SFX", 1f);
        SetResolution(0);
        SetVsync(true);
        SaveSettings();

        if (soundSettings != null)
        {
            soundSettings.LoadSettings();
        }

        if (resolutionSettings != null)
        {
            resolutionSettings.LoadResolutionSettings();
        }

        LoadVSync();
    }

    public void SetVolume(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public float GetVolume(string key)
    {
        return PlayerPrefs.GetFloat(key, 1f);
    }

    public void SetResolution(int resolutionIndex)
    {
        PlayerPrefs.SetInt("Resolution", resolutionIndex);
    }

    public int GetResolution()
    {
        return PlayerPrefs.GetInt("Resolution", 0);
    }

    public void SetVsync(bool isEnabled)
    {
        PlayerPrefs.SetInt("VSync", isEnabled ? 1 : 0);
        PlayerPrefs.Save();
        ApplyVsync(isEnabled);
    }

    private void ApplyVsync(bool isEnabled)
    {
        QualitySettings.vSyncCount = isEnabled ? 1 : 0;
    }

    public void OnVsyncToggleChanged(bool isOn)
    {
        SetVsync(isOn);
    }
}
