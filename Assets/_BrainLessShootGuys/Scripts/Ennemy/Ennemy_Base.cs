using UnityEngine;

public class Ennemy_Base : AEnnemy
{
    private float attaqueCD = 0;

    public override void Attaque()
    {
        if(attaqueCD >= fireRate)
        {
            PlayerMovement p = _player.GetComponent<PlayerMovement>();
            p.Damage(dammage, null);
            attaqueCD = 0;

            Vector3 direction = transform.forward.normalized;
            p.PushEffect(direction, 10f);                       
        }        
    }

    public override void Chase()
    {
        if(agent.enabled)
        {
            agent.SetDestination(_player.transform.position);            
        }        
    }

    public override void Update()
    {
        base.Update();

        if(attaqueCD <= fireRate) 
        { 
            attaqueCD += Time.deltaTime;
        }        
    }
}
