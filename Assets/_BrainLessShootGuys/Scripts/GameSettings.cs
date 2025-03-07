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

    #region Game
    public float health = 100;
    public float XP = 0;
    public int level = 1;
    public int kills = 0;
    #endregion
}
