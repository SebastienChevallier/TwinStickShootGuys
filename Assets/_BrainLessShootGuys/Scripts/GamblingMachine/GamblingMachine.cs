using System.Collections.Generic;
using UnityEngine;

public class GamblingMachine : MonoBehaviour
{
    [SerializeField] private List<string> lootName;
    [SerializeField] private float reloadingTime;
    private float timeSinceLastUse;

    [Header("Loots")]
    [SerializeField] private int minHealSpawn;
    [SerializeField] private int maxHealSpawn;
    [Space]
    [SerializeField] private int minXPSpawn;
    [SerializeField] private int maxXPSpawn;

    [Header("LootPrefabs")]
    [SerializeField] private Heal heal;
    [SerializeField] private XP xp;

    [Header("Throw Data")]
    [SerializeField] private float angle;
    [SerializeField] private float minThrowStrenght; 
    [SerializeField] private float maxThrowStrenght;

    private void Start()
    {
        timeSinceLastUse = reloadingTime;
    }

    private void Update()
    {
        if (timeSinceLastUse < reloadingTime) timeSinceLastUse += Time.deltaTime;
    }

    public void OpenGambling()
    {
        if (timeSinceLastUse < reloadingTime) return;

        timeSinceLastUse = 0;
        string loot = lootName[Random.Range(0, lootName.Count)];
        int nb = 0;
        Quaternion rot = new Quaternion(transform.rotation.x, 0, angle, transform.rotation.w);
        switch (loot)
        {
            case "Health":
                nb = Random.Range(minHealSpawn, maxHealSpawn);
                for (int i = 0; i < nb; i++)
                {
                    Heal item = Instantiate(heal,transform);
                    rot = new Quaternion(i * (360 / nb), angle, 0, transform.rotation.w);
                    item.transform.rotation = rot;
                    heal.Throw(Random.Range(minThrowStrenght, maxThrowStrenght), rot);
                }
                break;


            case "XP":
                nb = Random.Range(minXPSpawn, maxXPSpawn);
                for (int i = 0; i < nb; i++)
                {
                    XP item = Instantiate(xp, transform);
                    rot = new Quaternion(i * (360 / nb), angle , 0, transform.rotation.w);
                    item.transform.rotation = rot;
                    xp.Throw(Random.Range(minThrowStrenght, maxThrowStrenght), rot);
                }
                break;


            default:
                break;
        }
    }
}
