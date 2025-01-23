using System.Collections;
using UnityEngine;


[CreateAssetMenu(fileName = "BasicShotgun", menuName = "Scriptable Objects/WeaponType/Shotgun/basicShotgun", order = 1)]
public class Shotgun : Pistol
{
    public Vector2 sprayMinMax;
    public Vector2 bulletNumberMinMax;

    int bulletNumber;
    float spray;
    public override void InstantiateBullet()
    {
        base.InstantiateBullet();
        originWeapon.playerUse.StartCoroutine(DelayBetweenBullet());
    }

    IEnumerator DelayBetweenBullet()
    {
        for (int i = 0; i < bulletNumber; i++)
        {

            Bullet bullet = Instantiate(
                bulletType,
                originWeapon.playerUse._bulletSpawnTransform.position,
                originWeapon.playerUse._bulletSpawnTransform.rotation
                );

            bullet.weaponType = this;
            bullet.origin = originWeapon.playerUse.gameObject;
            bullet.transform.position = originWeapon.playerUse._bulletSpawnTransform.position;
            float randomRot = Random.Range(-spray, spray);
            bullet.transform.rotation = originWeapon.playerUse._bulletSpawnTransform.rotation;
            bullet.transform.localRotation *= Quaternion.Euler(0, randomRot, 0);
            bullet.transform.localScale = Vector3.one * bulletScale;
            bullet.rb.linearVelocity = bullet.transform.forward * bulletSpeed;
            yield return new WaitForEndOfFrame();
        }
    }

    public override void DefineStats()
    {
        base.DefineStats();
        spray = Random.Range(sprayMinMax.x, sprayMinMax.y);
        bulletNumber = (int)Random.Range(bulletNumberMinMax.x, bulletNumberMinMax.y);
    }
}
