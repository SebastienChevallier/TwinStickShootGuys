using System.Collections.Generic;
using UnityEngine;

public class WeaponType : ScriptableObject
{
    [Header("Bullet")]
    public Bullet bulletType;
    [Range(0f, 1f)]
    public float chanceSpecialBullets;
    public List<Bullet> specialBullets;
    public List<SO_Decorator> bulletDecorator;
    [Space(10)]


    public float damage;
    public Vector2 tireRateMinMax;
    public Vector2 consumJaugeMinMax;
    public float powerFeeling;

    public Weapon originWeapon;
    public float tireRate;
    public float consumJauge;

    public float jauge;

    public bool isPlayer;
    public PlayerMovement player;
    public virtual void Init(Weapon weapon)
    {
        originWeapon = weapon;
        //A changer par le player
        bulletType.origin = weapon.gameObject;
        jauge = 100;

        if (isPlayer)
        {
            player = originWeapon.GetComponentInParent<PlayerMovement>();
        }

    }
    public virtual void OnShoot()
    {
        
    }

    public virtual void ConsumJauge()
    {
        jauge -= consumJauge;

        if (isPlayer) {
            if (consumJauge > 0) { player._weaponGaugeHandler.UpdateUISlider(jauge); }
            //else { player._weaponGaugeHandler.UpdateUISlider(0); }
        }

        if (jauge <= 0)
        {
            jauge = 100;
            //originWeapon.playerUse.UnEquip();
        }
    }
    public virtual void StopShooting()
    {

    }

    public virtual void InstantiateBullet()
    {
        if (player) {
            
            player._animator.SetTrigger("Shoot");
            player.ShootEffect(powerFeeling);
        }
        //SoundManager.Instance.PlayAudio(AudioSound.Shoot, originWeapon.playerUse.transform.position);
        ConsumJauge();
    }

    public virtual void DefineStats()
    {
        tireRate = Random.Range(tireRateMinMax.x, tireRateMinMax.y);
        consumJauge = Random.Range(consumJaugeMinMax.x, consumJaugeMinMax.y);
        /*if (Random.Range(0f, 1f) <= chanceSpecialBullets)
        {
            bulletType = specialBullets[Random.Range(0, specialBullets.Count - 1)];
        }*/
    }

    public IBullet WrapBullet(IBullet bul)
    {
        foreach(SO_Decorator decorator in bulletDecorator)
        {
            bul = decorator.ApplyDecorator(bul);
        }
        return bul;
    }
}
