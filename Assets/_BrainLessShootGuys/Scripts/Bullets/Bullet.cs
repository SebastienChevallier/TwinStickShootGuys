using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    public GameObject origin;
    public LayerMask layerCanTouch;
    public Rigidbody rb;
    public WeaponType weaponType;
    public float destroyDelay = 5;

    public virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject != origin && (layerCanTouch.value & (1 << collision.transform.gameObject.layer)) > 0) {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Entity"))
                OnTouch(collision);

            Destroy(gameObject);
        }
    }

    public void Start()
    {
        Destroy(gameObject, destroyDelay);
    }

    public virtual void OnTouch(Collider collision)
    {
        IHealth player = collision.GetComponent<IHealth>();
        player.Damage(weaponType.damage, origin);
    }
}
