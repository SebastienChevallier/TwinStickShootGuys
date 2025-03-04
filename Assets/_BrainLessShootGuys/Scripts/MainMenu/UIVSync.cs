using UnityEngine;
using UnityEngine.UI;

public class UIVSync : MonoBehaviour
{
    public Toggle vSyncToggle;

    private void Start()
    {
        vSyncToggle.isOn = SaveManager.Instance.gameSettings.isVSyncEnabled;
        QualitySettings.vSyncCount = vSyncToggle.isOn ? 1 : 0;
        vSyncToggle.onValueChanged.AddListener(OnVSyncChanged);
    }

    private void OnVSyncChanged(bool isOn)
    {
        SaveManager.Instance.gameSettings.isVSyncEnabled = isOn;
        QualitySettings.vSyncCount = isOn ? 1 : 0;
    }
}
