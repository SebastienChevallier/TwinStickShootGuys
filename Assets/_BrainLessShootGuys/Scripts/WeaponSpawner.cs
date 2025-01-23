using System.Collections;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public float spawnWeaponTime;
    public Vector2 firstSpawnDelayMinMax;
    public Transform weaponVisualTransformParent;
    public ParticleSystem pickupParticles;

    public Weapon tempWeaponSpawn;
    bool isWeaponSpawn;

    private float firstSpawnDelay;
    private void Awake()
    {
        LevelManager.Instance.weaponSpawners.Add(this);
        firstSpawnDelay = Random.Range(firstSpawnDelayMinMax.x, firstSpawnDelayMinMax.y);
    }

    public void Init()
    {
        StartCoroutine(SpawnWeapon(true));
    }

    IEnumerator SpawnWeapon(bool isFirstTime)
    {
        if (isFirstTime)
            yield return new WaitForSeconds(firstSpawnDelay);
        else 
            yield return new WaitForSeconds(spawnWeaponTime);

        tempWeaponSpawn = Instantiate(LevelManager.Instance.weaponInMap[Random.Range(0, LevelManager.Instance.weaponInMap.Count)], weaponVisualTransformParent);
        tempWeaponSpawn.gameObject.SetActive(true);
        
        tempWeaponSpawn.enabled = false;
        isWeaponSpawn = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && tempWeaponSpawn != null)
        {
            if (other.TryGetComponent<PlayerMovement>(out PlayerMovement pm))
            {
                if (!pm.isEquipWeapon && isWeaponSpawn)
                {
                    pm.Equip(tempWeaponSpawn);
                    pickupParticles.Play();
                    isWeaponSpawn =false;
                    StartCoroutine(SpawnWeapon(false));
                }
            }
        }
    }
}
