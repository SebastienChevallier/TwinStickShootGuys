using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDropdown : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    private void Start()
    {
        Resolution[] resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        var options = new System.Collections.Generic.List<string>();

        foreach (Resolution resolution in resolutions)
        {
            options.Add(resolution.width + "x" + resolution.height);
        }

        resolutionDropdown.AddOptions(options);

        int currentResolutionIndex = GetCurrentResolutionIndex(resolutions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
    }

    private int GetCurrentResolutionIndex(Resolution[] resolutions)
    {
        int savedWidth = SaveManager.Instance.gameSettings.screenWidth;
        int savedHeight = SaveManager.Instance.gameSettings.screenHeight;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == savedWidth && resolutions[i].height == savedHeight)
            {
                return i;
            }
        }

        return 0;
    }

    private void OnResolutionChanged(int index)
    {
        Resolution[] resolutions = Screen.resolutions;
        Resolution selectedResolution = resolutions[index];

        SaveManager.Instance.gameSettings.screenWidth = selectedResolution.width;
        SaveManager.Instance.gameSettings.screenHeight = selectedResolution.height;

        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
    }
}
