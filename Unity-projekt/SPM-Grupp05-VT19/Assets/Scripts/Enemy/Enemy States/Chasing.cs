using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Chasing")]
public class Chasing : EnemyBaseState
{
    public override void HandleUpdate()
    {
        if (playerDistance > 20.0f)
        {
            owner.Transition<Idle>();
        }
        else if (playerDistance < 10.0f)
        {
            owner.Transition<Attack>();
        }
    }
}
