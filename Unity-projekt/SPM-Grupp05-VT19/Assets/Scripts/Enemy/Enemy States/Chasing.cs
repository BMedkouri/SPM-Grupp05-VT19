using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Chasing")]
public class Chasing : EnemyBaseState
{
    public override void Enter()
    {
        base.Enter();
    }
    public override void HandleUpdate()
    {
        if (GetDistance() > 20.0f || !CanSeePlayer())
        {
            owner.Transition<Idle>();
        }
        else if (GetDistance() < 2.6f && CanSeePlayer())
        {
            owner.Transition<Attack>();
        }
        move();
    }
    private void move()
    {
       
        Vector3 movement = owner.player.transform.position - owner.transform.position;
        Vector3 direction = movement / GetDistance();
        owner.physics.Accelerate(direction, moveSpeed, turnSpeedModifier);
    }
}
