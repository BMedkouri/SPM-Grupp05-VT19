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
        if (owner.GetDistance() > 20.0f || !owner.CanSeePlayer())
        {
            owner.Transition<EnemyIdleState>();
        }

        if (owner.GetDistance() < 2.6f && owner.CanSeePlayer())
        {
            owner.Transition<EnemyAttackState>();
        }

        ChasePlayer();
    }

    private void ChasePlayer()
    {
        Vector3 direction = (owner.player.transform.position - owner.transform.position) / owner.GetDistance();
        owner.physics.Accelerate(direction, movementSpeed, turnSpeedModifier);
    }
}
