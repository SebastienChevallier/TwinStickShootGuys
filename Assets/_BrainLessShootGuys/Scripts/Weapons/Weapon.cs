using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    public WeaponVisual weaponVisual;
    public ActifSpell actifSpell;
    public WeaponType weaponType;
    public Transform weaponVisualParent;
    public AEntity entityUse;
    public virtual void Init()
    {
        //actifSpell.Init(this);
        weaponType.Init(this);
    }

    public void Shoot() {
        weaponType.OnShoot();
        weaponVisual.OnShoot();
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
