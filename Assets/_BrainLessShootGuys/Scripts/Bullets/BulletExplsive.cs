using UnityEngine;

public class BulletExplosive : Bullet
{
    public float explosionForce = 5f;
    public override void OnTouch(Collider collision)
    {
        PlayerMovement player = collision.GetComponent<PlayerMovement>();

        //Vector3 direction = (player.transform.position - transform.position).normalized;

        Vector3 direction = transform.forward.normalized;        
        player.PushEffect(direction, explosionForce);
        player.Damage(weaponType.damage, origin);

        //gameObject.SetActive(false);
    }
}
