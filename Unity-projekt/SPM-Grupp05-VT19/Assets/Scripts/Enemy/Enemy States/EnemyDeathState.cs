using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/EnemyDeathState")]
public class EnemyDeathState : EnemyBaseState
{
    // Methods
    public override void Enter()
    {
        DeathEvent deathEvent = new DeathEvent
        {
            DyingGameObject = owner.gameObject,
            DeathSound = owner.GetDeathSound(),
            DeathParticle = owner.GetDeathParticle()
        };
        deathEvent.FireEvent();
    }
}
