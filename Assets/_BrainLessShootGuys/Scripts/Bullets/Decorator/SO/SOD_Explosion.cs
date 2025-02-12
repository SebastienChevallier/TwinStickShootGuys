using UnityEngine;

[CreateAssetMenu(fileName = "SOD_Explosion", menuName = "Scriptable Objects/SOD_Explosion")]
public class SOD_Explosion : SO_Decorator
{
    public override IBullet ApplyDecorator(IBullet bullet)
    {
        bullet = new DExplosion(bullet);
        return bullet;
    }
}
