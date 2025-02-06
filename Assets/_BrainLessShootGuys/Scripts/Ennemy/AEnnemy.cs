using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;

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
    protected Rigidbody rb;

    public virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        SetupEnnemy();
    }

    public virtual void SetupEnnemy()
    {
        agent.speed = speed;
        actualLife = maxLife;
    }

    public abstract void Attaque();
    public abstract void Chase();

    IEnumerator PushBack(float power, GameObject origin)
    {
        agent.enabled = false;
        Vector3 dir = transform.position - origin.transform.position;
        rb.AddRelativeForce(dir * 0.05f, ForceMode.Impulse);


        yield return new WaitForSeconds(power * 0.05f);
        agent.enabled = true;        
    }

    public void Damage(float dmg, GameObject PlayerOrigin)
    {
        PlayerInput player = PlayerOrigin.GetComponent<PlayerInput>();
        _player = player.gameObject;

        if (player != null)
        {
            if (dmg < actualLife)
            {
                actualLife -= dmg;
                Debug.Log("Hit");
                StartCoroutine(PushBack(dmg, PlayerOrigin));
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
                agent.isStopped = true;
                Attaque();
            }
            else
            {
                agent.isStopped = false;
                Chase();
            }
        }
    }
}
