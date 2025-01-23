using System.Collections;
using UnityEngine;

public class Pistol : WeaponType
{
    public Vector2 bulletSpeedMinMax;
    public Vector2 bulletScaleMinMax;
    public float bulletSpeed;
    
    protected float bulletScale;

    protected bool canShoot = true;
    public override void Init(Weapon weapon)
    {
        base.Init(weapon);
        canShoot = true;
    }
    public override void OnShoot()
    {
        if (!canShoot)
            return;

        base.OnShoot();
        InstantiateBullet();
        originWeapon.StartCoroutine(WaitingForShoot());
    }

    public override void InstantiateBullet()
    {
        base.InstantiateBullet();
    }

    public virtual IEnumerator WaitingForShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(tireRate);
        canShoot = true;
    }

    public override void DefineStats()
    {
        base.DefineStats();
        bulletSpeed = Random.Range(bulletSpeedMinMax.x, bulletSpeedMinMax.y);
        bulletScale = Random.Range(bulletScaleMinMax.x, bulletScaleMinMax.y);
    }
}
