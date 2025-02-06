using System.Collections;
using UnityEngine;


[CreateAssetMenu(fileName = "CacGun", menuName = "Scriptable Objects/WeaponType/CacGun/basicCacGun", order = 1)]
public class CacGun : Rifle
{
    public Vector2 sprayMinMax;
    public Vector2 bulletNumberMinMax;
    public Vector2 bulletDispawnTimeMinMax;

    int bulletNumber;
    float spray;
    public override void InstantiateBullet()
    {
        base.InstantiateBullet();
        originWeapon.entityUse.StartCoroutine(DelayBetweenBullet());
    }

    IEnumerator DelayBetweenBullet()
    {
        for (int i = 0; i < bulletNumber; i++)
        {

            Bullet bullet = Instantiate(
                bulletType,
                originWeapon.entityUse._bulletSpawnTransform.position,
                originWeapon.entityUse._bulletSpawnTransform.rotation
                );

            bullet.weaponType = this;
            bullet.origin = originWeapon.entityUse.gameObject;
            bullet.transform.position = originWeapon.entityUse._bulletSpawnTransform.position;
            float randomRot = Random.Range(-spray, spray);
            bullet.transform.rotation = originWeapon.entityUse._bulletSpawnTransform.rotation;
            bullet.transform.localRotation *= Quaternion.Euler(0, randomRot, 0);
            bullet.transform.localScale = Vector3.one * .2f;
            bullet.rb.linearVelocity = bullet.transform.forward * bulletSpeed;
            if (bulletDispawnTimeMinMax.y > 0)
            {
                Destroy(bullet.gameObject, Random.Range(bulletDispawnTimeMinMax.x, bulletDispawnTimeMinMax.y));
            }
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
