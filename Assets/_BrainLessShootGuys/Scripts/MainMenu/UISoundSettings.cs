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
        masterSlider.value = UIMenuSettings.Instance.GetVolume("Master");
        musicSlider.value = UIMenuSettings.Instance.GetVolume("Music");
        sfxSlider.value = UIMenuSettings.Instance.GetVolume("SFX");
    }

    private void OnMasterVolumeChanged(float value)
    {
        UIMenuSettings.Instance.SetVolume("Master", value);
        SoundManager.Instance.UpdateVolumes();
    }

    private void OnMusicVolumeChanged(float value)
    {
        UIMenuSettings.Instance.SetVolume("Music", value);
        SoundManager.Instance.UpdateVolumes();
    }

    private void OnSFXVolumeChanged(float value)
    {
        UIMenuSettings.Instance.SetVolume("SFX", value);
        SoundManager.Instance.UpdateVolumes();
    }
}
