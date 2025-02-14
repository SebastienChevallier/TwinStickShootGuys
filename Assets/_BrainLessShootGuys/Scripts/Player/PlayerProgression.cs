using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerProgression : MonoBehaviour
{
    [Header("Progression")]
    [SerializeField] private float initialProgressionNeeded;
    [SerializeField] private float incrementalProgression;
    private int level;
    private float progress;
    private float progressNeeded;

    [Header("Visuals")]
    [SerializeField] private TextMeshProUGUI levelTxt;
    [SerializeField] private UnityEngine.UI.Slider progressBar;
    [SerializeField] private TextMeshProUGUI upgradeTxt;
    [SerializeField] private Animator upgradeAnim;

    [Header("Upgrades")]
    [SerializeField] private float maxSpeedUpgrade;
    [SerializeField] private float maxHealth;
    [SerializeField] private float maxDashForce;
    [SerializeField] private float maxDashCD;
    [SerializeField] private float maxHPRegen;
    [SerializeField] private float maxCritic;
    [SerializeField] private float maxCriticDammage;
    [SerializeField] private float maxRotationSpeed;



    private void Start()
    {
        progressNeeded = initialProgressionNeeded;
        level = 1;
        levelTxt.text = level.ToString();
        progressBar.value = 0;
    }

    public void AddLevelProgression(float additionnalProgress)
    {
        progress += additionnalProgress;
        if (progress >= progressNeeded)
        {
            LevelUp();
        }
        UpdateProgressBar();
    }
    private void LevelUp()
    {
        level++;
        progress -= progressNeeded;
        if (progress < 0) progress = 0;
        progressNeeded *= incrementalProgression;
        UpdateLevel();
    }
    #region Updates
    private void UpdateLevel()
    {
        levelTxt.text = level.ToString();
        Stat upgradedStat = (Stat)Random.Range(0, 7);
        PlayerMovement player = GetComponent<PlayerMovement>();
        int truncate = 0;
        switch (upgradedStat)
        {
            case Stat.Speed:
                float randomSpeed = Random.Range(0, maxSpeedUpgrade);
                randomSpeed *= 100;
                truncate = (int)randomSpeed;
                randomSpeed = truncate;
                randomSpeed /= 100;
                upgradeTxt.text = $"+ " + randomSpeed + " Speed";
                player._stats.ModifyStat(Stat.Speed, randomSpeed);
                    break;

            case Stat.DashCD:
                float randomDashCD = Random.Range(0, maxSpeedUpgrade);
                randomDashCD *= 100;
                truncate = (int)randomDashCD;
                randomDashCD = truncate;
                randomDashCD /= 100;
                upgradeTxt.text = $"- " + randomDashCD + " Dash couldown";
                player._stats.ModifyStat(Stat.DashCD, -randomDashCD);
                break;

            case Stat.DashForce:
                float randomDashForce = Random.Range(0, maxSpeedUpgrade);
                randomDashForce *= 100; 
                truncate = (int)randomDashForce;
                randomDashForce = truncate;
                randomDashForce /= 100;
                upgradeTxt.text = $"+ " + randomDashForce + " Dash force";
                player._stats.ModifyStat(Stat.DashForce, randomDashForce);
                break;

            case Stat.Critic:
                float randomCrit = Random.Range(0, maxSpeedUpgrade);
                randomCrit *= 100;
                truncate = (int)randomCrit;
                randomCrit = truncate;
                randomCrit /= 100;
                upgradeTxt.text = $"+ " + randomCrit + " Critical chance";
                player._stats.ModifyStat(Stat.Critic, randomCrit);
                break;

            case Stat.CriticDammage:
                float randomCritDamage = Random.Range(0, maxSpeedUpgrade);
                randomCritDamage *= 100;
                truncate = (int)randomCritDamage;
                randomCritDamage = truncate;
                randomCritDamage /= 100;
                upgradeTxt.text = $"+ " + randomCritDamage + " Critical damage";
                player._stats.ModifyStat(Stat.CriticDammage, randomCritDamage);
                break;

            case Stat.Health:
                float randomHealth = Random.Range(0, maxSpeedUpgrade);
                randomHealth *= 100;
                truncate = (int)randomHealth;
                randomHealth = truncate;
                randomHealth /= 100;
                upgradeTxt.text = $"+ " + randomHealth + " Health";
                player._stats.ModifyStat(Stat.Health, randomHealth);
                break;

            case Stat.HPRegen:
                float randomRegen = Random.Range(0, maxSpeedUpgrade);
                randomRegen *= 100;
                truncate = (int)randomRegen;
                randomRegen = truncate;
                randomRegen /= 100;
                upgradeTxt.text = $"+ " + randomRegen + " Regen";
                player._stats.ModifyStat(Stat.HPRegen, randomRegen);
                break;

            case Stat.RotationSpeed:
                float randomRota = Random.Range(0, maxSpeedUpgrade);
                randomRota *= 100;
                truncate = (int)randomRota;
                randomRota = truncate;
                randomRota /= 100;
                upgradeTxt.text = $"+ " + randomRota + " Rotation speed";
                player._stats.ModifyStat(Stat.RotationSpeed, randomRota);
                break;
        }
        upgradeAnim.SetTrigger("Upgrade");
        UpdateProgressBar();
    }

    private void UpdateProgressBar()
    {
        progressBar.value = progress * 100 / progressNeeded;
    }
    #endregion
}
