using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<AEnnemy> enemies;
    public List<AEnnemy> eliteEnemies;
    [Range(0, 1)]
    public float eliteEnemiesSpawnChance;

    public Vector2 spawnEnemyTimeMinMax;
    public Transform spawnEnemiesTransform;
    public float enemySpawnDistanceToPlayer;

    public PlayerMovement playerMovement;

    public void Start()
    {
        StartCoroutine(WaitAndSpawnEnemy());
    }

    IEnumerator WaitAndSpawnEnemy()
    {
        while (playerMovement)
        {
            yield return new WaitForSeconds(Random.Range(spawnEnemyTimeMinMax.x, spawnEnemyTimeMinMax.y));

            AEnnemy newEnemy;
            if (Random.Range(0,1) >= eliteEnemiesSpawnChance)
                newEnemy = Instantiate(enemies[Random.Range(0, enemies.Count)], spawnEnemiesTransform);
            else
                newEnemy = Instantiate(eliteEnemies[Random.Range(0,eliteEnemies.Count)], spawnEnemiesTransform);

            Vector2 randomPos = GetRandomPointOnCircle(enemySpawnDistanceToPlayer);

            newEnemy.transform.position = new Vector3(playerMovement.transform.position.x + randomPos.x, .3f, playerMovement.transform.position.z + randomPos.y);
        }
    }

    private Vector2 GetRandomPointOnCircle(float radius)
    {
        // Choisir un angle aléatoire entre 0 et 360 degrés
        float angle = Random.Range(0f, Mathf.PI * 2);

        // Calculer les coordonnées sur le cercle
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        return new Vector2(x, y);
    }
}
