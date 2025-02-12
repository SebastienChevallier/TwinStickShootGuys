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

        IBullet decoratedBullet = WrapBullet(bullet);

        if (decoratedBullet is Bullet b)
        {
            bullet = b;
        }
        else if (decoratedBullet is ADecorator decorator && decorator is ADecorator)
        {
            bullet = decorator.bulletInstance; // Récupère la vraie instance de Bullet
        }
        else
        {
            Debug.LogError("Wrapped bullet is not a Bullet instance!");
        }

        bullet.weaponType = this;
        bullet.origin = originWeapon.entityUse.gameObject;
        bullet.transform.position = originWeapon.entityUse._bulletSpawnTransform.position;
        bullet.transform.rotation = originWeapon.entityUse._bulletSpawnTransform.rotation;
        bullet.transform.localScale = Vector3.one * 0.1f;
        //Debug.Log(bullet.transform.localScale);
        bullet.rb.linearVelocity = originWeapon.entityUse._bulletSpawnTransform.forward * bulletSpeed;
    }
}
