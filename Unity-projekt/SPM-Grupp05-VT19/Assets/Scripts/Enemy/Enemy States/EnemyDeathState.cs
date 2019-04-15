using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/EnemyDeathState")]
public class EnemyDeathState : EnemyBaseState
{
    // Methods
    public override void Enter()
    {
        base.Enter();

        //Plays animation
        owner.animator.Play("EnemyDeathAnimation");
    }

    public override void HandleUpdate()
    {
        
    }
}
