using UnityEngine;
[CreateAssetMenu(fileName = "BasicPistol", menuName = "Scriptable Objects/WeaponType/Pistol/basicPistol", order = 1)]

public class BasicPistol : Pistol
{
    
    public override void InstantiateBullet()
    {
        base.InstantiateBullet();

        Bullet bullet = Instantiate(
            bulletType, 
            originWeapon.playerUse._bulletSpawnTransform.position,
            originWeapon.playerUse._bulletSpawnTransform.rotation
            );

        bullet.weaponType = this;
        bullet.origin = originWeapon.playerUse.gameObject;
        bullet.transform.position = originWeapon.playerUse._bulletSpawnTransform.position;
        bullet.transform.rotation = originWeapon.playerUse._bulletSpawnTransform.rotation;
        bullet.transform.localScale = Vector3.one * bulletScale;
        bullet.rb.linearVelocity = originWeapon.playerUse._bulletSpawnTransform.forward * bulletSpeed;
    }
}
