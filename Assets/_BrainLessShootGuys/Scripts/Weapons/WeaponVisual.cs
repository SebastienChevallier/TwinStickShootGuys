using UnityEngine;
public class  WeaponVisual : MonoBehaviour
{
    public bool isWorldParticle;
    public ParticleSystem shootParticles;

    public void OnShoot()
    {
        shootParticles.Play();
    }
}
