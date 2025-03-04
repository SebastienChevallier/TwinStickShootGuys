using UnityEngine;
using UnityEngine.Rendering;

public class Heal : MonoBehaviour
{
    [SerializeField] private float healthQTT;
    [SerializeField] private Rigidbody rb;

    private void Update()
    {
    }

    public void Throw(float strength, Quaternion rot)
    {
        //transform.localRotation = rot;
        //Vector3 dir = new Vector3(0, strength, 0);
        rb.AddForce(transform.forward * 1000, ForceMode.Impulse);
        print(rb.linearVelocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerMovement>().AddHealth(healthQTT);
            Destroy(this.gameObject);
        }
    }
}
