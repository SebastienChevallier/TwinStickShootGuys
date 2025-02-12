using UnityEngine;

public class DExplosion : ADecorator
{
    public DExplosion(IBullet bullet) : base(bullet)
    {
        
    }

    public override void OnTouch(Collider collision)
    {
        pBullet.OnTouch(collision);
        Debug.Log("Explosion");
    }
}
