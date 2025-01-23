using UnityEngine;

public class ActifSpell : ScriptableObject
{
    public Weapon originWeapon;
    public virtual void Init(Weapon weapon)
    {
        originWeapon = weapon;
    }
    public virtual void OnUse()
    {

    }
}
