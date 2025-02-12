using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

abstract public class AEnnemy : AEntity, IHealth
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
    public PlayerInput player;

    public virtual void Start()
    {
        actualLife = maxLife;
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        SetupEnnemy();
    }

    public virtual void SetupEnnemy()
    {
        agent.speed = speed;
        actualLife = maxLife;
        agent.enabled = true;
    }

    public abstract void Attaque();
    public abstract void Chase();

    public override void PushEffect(Vector3 direction, float force)
    {
        base.PushEffect(direction,force);
        //StartCoroutine(PushBack(dmg, PlayerOrigin));
    }

    IEnumerator PushBack(float power, GameObject origin)
    {
        agent.enabled = false;
        Vector3 dir = transform.position - origin.transform.position;
        rb.AddRelativeForce(dir * 0.05f, ForceMode.Impulse);


        yield return new WaitForSeconds(power * 0.05f);
        agent.enabled = true;        
    }

    public override void Damage(float dmg, GameObject PlayerOrigin)
    {

        if (player != null)
        {
            if (dmg < actualLife)
            {
                actualLife -= dmg;
                //Debug.Log("Hit");
                //StartCoroutine(PushBack(dmg, PlayerOrigin));
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
        if (PlayerManager.Instance.players.Count > 0)
        {
            _player = PlayerManager.Instance.players[0].gameObject;

            if (Vector3.Distance(transform.position, _player.transform.position) <= range)
            {
                agent.ResetPath();
                Attaque();
                print("trop proooche");
            }
            else
            {
                Chase();
                agent.SetDestination(_player.transform.position);
            }
        }
    }
}
