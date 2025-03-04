[System.Serializable]
public class GameSettings
{
    #region sounds settings
    public float masterVolume = 1f;
    public float musicVolume = 1f;
    public float sfxVolume = 1f;
    #endregion

    public int screenWidth = 1920;
    public int screenHeight = 1080;
    public bool isVSyncEnabled = true;
}
