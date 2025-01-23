using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

abstract public class AEnnemy : MonoBehaviour, IHealth
{
    public float actualLife;
    public float maxLife;
    public float speed;
    public float fireRate;
    public float range;
    public float dammage;

    protected GameObject _player;
    protected NavMeshAgent agent;

    public virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetupEnnemy();
    }

    public virtual void SetupEnnemy()
    {
        agent.speed = speed;
        actualLife = maxLife;
    }

    public abstract void Attaque();
    public abstract void Chase();

    public void Dammage(float dmg, GameObject PlayerOrigin)
    {
        PlayerInput player = PlayerOrigin.GetComponent<PlayerInput>();
        _player = player.gameObject;

        if (player != null)
        {
            if (dmg < actualLife)
            {
                actualLife -= dmg;
                Debug.Log("Hit");
            }
            else
            {                
                GameManager.Instance.AddPoint(player);
                Destroy(gameObject);
            }
        }
        
    }

    public virtual void Update()
    {        
        if (_player != null)
        {            
            if (Vector3.Distance(transform.position, _player.transform.position) <= range)
            {
                Attaque();
            }
            else
            {
                Chase();
            }
        }
    }
}
