using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/EnemyDeathState")]
public class EnemyDeathState : EnemyBaseState
{
    // Methods
    public override void Enter()
    {
       // base.Enter();

        //owner.renderer.enabled = false;
        //Plays animation
        //owner.animator.Play("EnemyDeathAnimation");
        
        owner.destroyEnemy();
    }

    public override void HandleUpdate()
    {
        
    }
}
