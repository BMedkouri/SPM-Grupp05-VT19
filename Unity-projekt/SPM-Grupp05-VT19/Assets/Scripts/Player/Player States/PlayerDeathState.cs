using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerDeathState")]
public class PlayerDeathState : PlayerBaseState
{
    // Methods
    public override void Enter()
    {
        base.Enter();

        //Plays animation
        owner.animator.Play("PlayerDeathAnimation");
    }

    public override void HandleUpdate()
    {
        
    }
}
