using UnityEngine;

public class AEntity : MonoBehaviour, IHealth
{
    public Transform _bulletSpawnTransform;
    public Transform _weaponAnchor;

    public virtual void Damage(float dmg, GameObject PlayerOrigin)
    {
    }

    public virtual void PushEffect(Vector3 direction, float force) { }

}
