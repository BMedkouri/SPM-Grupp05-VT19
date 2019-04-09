using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/IdleState")]
public class EnemyIdleState : EnemyBaseState
{
    public override void Enter()
    {
        base.Enter();
    }
    public override void HandleUpdate()
    {
        base.HandleUpdate();

        if(owner.GetDistance() < 20.0f && owner.CanSeePlayer())
        {
            owner.Transition<EnemyChaseState>();
        }
    }
}
