using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicRifle", menuName = "Scriptable Objects/WeaponType/Rifle/basicRifle", order = 1)]
public class BasicRifle : Rifle
{
    public float bulletScale;
    public override void InstantiateBullet()
    {
        base.InstantiateBullet();
        Bullet bullet = Instantiate(
            bulletType,
            originWeapon.entityUse._bulletSpawnTransform.position,
            originWeapon.entityUse._bulletSpawnTransform.rotation
            );

        bullet.weaponType = this;
        bullet.origin = originWeapon.entityUse.gameObject;
        bullet.transform.position = originWeapon.entityUse._bulletSpawnTransform.position;
        bullet.transform.rotation = originWeapon.entityUse._bulletSpawnTransform.rotation;
        //bullet.transform.localScale = Vector3.one * bulletScale;
        bullet.rb.linearVelocity = originWeapon.entityUse._bulletSpawnTransform.forward * bulletSpeed;
    }
}