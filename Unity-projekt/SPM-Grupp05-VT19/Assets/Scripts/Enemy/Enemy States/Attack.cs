using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Attack")]
public class Attack : EnemyBaseState
{
    public override void HandleUpdate()
    {
        if (owner.getDistance() > 10.0f)
        {
            owner.Transition<Chasing>();
        }
    }
}