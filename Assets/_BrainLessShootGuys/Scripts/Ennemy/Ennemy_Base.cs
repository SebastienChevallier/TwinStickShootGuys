using UnityEngine;

public class Ennemy_Base : AEnnemy
{
    public float attaqueCD = 0;

    public override void Attaque()
    {
        if(attaqueCD >= fireRate)
        {
            IHealth p = _player.GetComponent<IHealth>();
            p.Dammage(dammage, null);
            attaqueCD = 0;
            Debug.Log("Attaque");
        }
        
    }

    public override void Chase()
    {
        agent.SetDestination(_player.transform.position);
        Debug.Log("Chase");
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
