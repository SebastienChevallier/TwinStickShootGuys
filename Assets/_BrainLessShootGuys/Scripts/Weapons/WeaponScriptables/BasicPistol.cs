using UnityEngine;
[CreateAssetMenu(fileName = "BasicPistol", menuName = "Scriptable Objects/WeaponType/Pistol/basicPistol", order = 1)]

public class BasicPistol : Pistol
{
    
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
        //bullet.transform.localScale = Vector3.one * 0.1f;
        //Debug.Log(bullet.transform.localScale);
        bullet.rb.linearVelocity = originWeapon.entityUse._bulletSpawnTransform.forward * bulletSpeed;
    }
}
