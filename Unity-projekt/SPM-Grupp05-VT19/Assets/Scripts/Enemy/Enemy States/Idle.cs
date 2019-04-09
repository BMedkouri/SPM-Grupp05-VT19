using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Idle")]
public class Idle : EnemyBaseState
{
    public override void Enter()
    {
        base.Enter();
    }
    public override void HandleUpdate()
    {
        base.HandleUpdate();
        if(GetDistance()< 20.0f && CanSeePlayer())
        {
            owner.Transition<Chasing>();
        }
    }
}
