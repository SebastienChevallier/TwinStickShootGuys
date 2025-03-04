using UnityEngine;
using UnityEngine.UI;

public class SoundSettingsUI : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        masterSlider.onValueChanged.AddListener(OnSoundSettingChanged);
        musicSlider.onValueChanged.AddListener(OnSoundSettingChanged);
        sfxSlider.onValueChanged.AddListener(OnSoundSettingChanged);
    }

    private void OnSoundSettingChanged(float value)
    {
        SettingsManager.Instance.SaveSettings();
    }
}
