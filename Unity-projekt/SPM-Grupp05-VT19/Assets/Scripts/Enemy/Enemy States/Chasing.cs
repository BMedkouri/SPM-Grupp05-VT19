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
        base.HandleUpdate();
        if (owner.getDistance() > 20.0f)
        {
            owner.Transition<Idle>();
        }
        else if (owner.getDistance() < 10.0f)
        {
            owner.Transition<Attack>();
        }
    }
}
