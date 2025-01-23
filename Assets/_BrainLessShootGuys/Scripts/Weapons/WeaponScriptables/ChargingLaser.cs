using System.Collections;
using UnityEngine;

public class ChargingLaser : WeaponType
{
    public Vector2 chargingTimeMinMax;

    protected bool canShoot = true;

    protected float chargingTime;
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
        originWeapon.StartCoroutine(Charging());
    }

    public override void InstantiateBullet()
    {
        base.InstantiateBullet();
    }

    public virtual IEnumerator Charging()
    {
        canShoot = false;
        yield return new WaitForSeconds(tireRate);
        canShoot = true;
    }

    public override void DefineStats()
    {
        base.DefineStats();
        chargingTime = Random.Range(chargingTimeMinMax.x, chargingTimeMinMax.y);
        //damage 
    }

}
