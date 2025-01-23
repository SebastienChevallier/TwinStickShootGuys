using UnityEngine;

[CreateAssetMenu(fileName = "BasicSword", menuName = "Scriptable Objects/WeaponType/Sword/BasicSword", order = 1)]
public class Sword : WeaponType
{
    private bool canAttack;
    public override void ConsumJauge()
    {
        base.ConsumJauge();
    }

    public override void Init(Weapon weapon)
    {
        base.Init(weapon);
    }
    public override void OnShoot()
    {
        if (!canAttack)
            //return;

        base.OnShoot();
        canAttack = false;
    }
    public override void DefineStats()
    {
        base.DefineStats();
    }
}
