using UnityEngine;
public class  WeaponVisual : MonoBehaviour
{
    public ParticleSystem shootParticles;
    public void OnShoot()
    {
        shootParticles.Play();
    }
}
