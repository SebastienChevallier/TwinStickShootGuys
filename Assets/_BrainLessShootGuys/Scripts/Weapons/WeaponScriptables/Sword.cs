using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicSword", menuName = "Scriptable Objects/WeaponType/Sword/BasicSword", order = 1)]
public class Sword : WeaponType
{
    public float attackDelay;

    [Header("AttackCollider")]
    public LayerMask attackLayerTarget;

    public float cacAttackDistance;
    public float cacAttackArcRadius;

    public float swordProjectileSize;

    [Space(5)]
    private bool canAttack;
    public override void ConsumJauge()
    {
        base.ConsumJauge();
    }

    public override void Init(Weapon weapon)
    {
        base.Init(weapon);
        canAttack = true;
    }
    public override void OnShoot()
    {
        if (!canAttack)
            return;
        base.OnShoot();

        // Obtenir tous les objets dans un rayon autour de l'origine
        Collider[] hits = Physics.OverlapSphere(originWeapon.playerUse.transform.position, cacAttackDistance, attackLayerTarget);

        foreach (Collider hit in hits)
        {
            Vector3 directionToTarget = hit.transform.position - originWeapon.playerUse.transform.position;
            directionToTarget.y = 0;

            float angleToTarget = Vector3.Angle(originWeapon.playerUse._visualTranform.transform.forward, directionToTarget);

            // Vérifier si l'objet est dans l'arc
            if (angleToTarget <= cacAttackArcRadius / 2)
            {
                Debug.Log("Hit: " + hit.name);
                IHealth targetTouch = hit.GetComponent<IHealth>();
                targetTouch.Dammage(damage, originWeapon.playerUse.gameObject);
            }
        }

        originWeapon.StartCoroutine(AttackDelay());
    }

    IEnumerator AttackDelay()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }
    public override void DefineStats()
    {
        base.DefineStats();
    }
}
