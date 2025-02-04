using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    public WeaponVisual weaponVisual;
    public ActifSpell actifSpell;
    public WeaponType weaponType;
    public Transform weaponVisualParent;
    public PlayerMovement playerUse;

    public bool canAttack;
    public virtual void Init()
    {
        //actifSpell.Init(this);
        weaponType.Init(this);
    }

    public void Shoot() {
        if (canAttack)
        {
            weaponType.OnShoot();
            weaponVisual.OnShoot();
        }
    }

    public void StopShooting()
    {
        weaponType.StopShooting();
    }

    public void UseActifSpell()
    {
        actifSpell.OnUse();
    }
}
