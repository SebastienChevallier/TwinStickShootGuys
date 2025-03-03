using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [Header("Sliders")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        LoadSettings();

        masterSlider.onValueChanged.AddListener(OnMasterVolumeChanged);
        musicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
    }

    public void LoadSettings()
    {
        masterSlider.value = UISettingManager.Instance.GetVolume("Master");
        musicSlider.value = UISettingManager.Instance.GetVolume("Music");
        sfxSlider.value = UISettingManager.Instance.GetVolume("SFX");
    }

    private void OnMasterVolumeChanged(float value)
    {
        UISettingManager.Instance.SetVolume("Master", value);
    }

    private void OnMusicVolumeChanged(float value)
    {
        UISettingManager.Instance.SetVolume("Music", value);
    }

    private void OnSFXVolumeChanged(float value)
    {
        UISettingManager.Instance.SetVolume("SFX", value);
    }
}
