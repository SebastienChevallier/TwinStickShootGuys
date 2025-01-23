using UnityEngine;

public class BounceBullet : Bullet
{
    public float bounceForce = 10f; // Force du rebond
    public int maxBounces = 3; // Nombre maximum de rebonds
    private int currentBounces = 0; // Compteur de rebonds

    public override void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject != origin && (layerCanTouch.value & (1 << collision.transform.gameObject.layer)) > 0) {
            
            if(collision.gameObject.layer == LayerMask.NameToLayer("Player")) 
            { 
                OnTouch(collision);
                Destroy(gameObject);
            }                       
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        HandleWallCollision(collision);
    }

    private void HandleWallCollision(Collision collision)
    {
        
        if (currentBounces < maxBounces)
        {
            //Debug.Break();
            // Approximation de la normale bas�e sur la position relative
            Vector3 inNormal = collision.contacts[0].normal;
            Vector3 newVelocity = Vector3.Reflect(rb.linearVelocity, inNormal);

            rb.linearVelocity = newVelocity;

            currentBounces++;
        }
        else
        {
            Destroy(gameObject); // D�truire la balle apr�s le nombre maximum de rebonds
        }
    }
}
