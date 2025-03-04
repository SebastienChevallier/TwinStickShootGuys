using UnityEngine;

public class XP : MonoBehaviour
{
    [SerializeField] private float xpQTT;
    [SerializeField] private Rigidbody rb;

    public void Throw(float strength, Quaternion rot)
    {
        //transform.localRotation = rot;
        //Vector3 dir = new Vector3(0, strength, 0);
        rb.AddForce(transform.up * 1000, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerProgression>().AddLevelProgression(xpQTT);
        }
    }
}
