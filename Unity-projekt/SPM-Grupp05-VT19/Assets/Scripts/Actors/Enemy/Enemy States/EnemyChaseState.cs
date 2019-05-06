using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/EnemyChaseState")]
public class EnemyChaseState : EnemyBaseState
{
    public override void Enter()
    {
        base.Enter();
    
    }

    //Ändra floats till variabler som kan ändras i inspector
    public override void HandleUpdate()
    {
        
        owner.agent.SetDestination(owner.player.transform.position);

        if (owner.GetDistance() > 20.0f || !owner.CanSeePlayer())
        {
            owner.Transition<EnemyIdleState>();
        }

        if (owner.GetDistance() < owner.agent.stoppingDistance && owner.CanSeePlayer())
        {
            owner.agent.acceleration = 60f;
            owner.Transition<EnemyCombatState>();
        }
        
        base.HandleUpdate();
        //ChasePlayer();
    }

    private void ChasePlayer()
    {
        Vector3 direction = (owner.player.transform.position - owner.transform.position) / owner.GetDistance();
        owner.physics.Accelerate(direction, movementSpeed, turnSpeedModifier);
    }
   
}
