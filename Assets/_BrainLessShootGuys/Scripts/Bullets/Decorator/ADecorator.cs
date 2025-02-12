using UnityEngine;

public abstract class ADecorator : IBullet
{
    protected IBullet pBullet { get; set; }
    public Bullet bulletInstance;
    public ADecorator(IBullet bullet) 
    {
        pBullet = bullet;
        if (bullet is Bullet b)
        {
            bulletInstance = b;
        }
    }
    public virtual void OnTouch(Collider collision)
    {
        Debug.Log("BasicDecorator");
    }
}
