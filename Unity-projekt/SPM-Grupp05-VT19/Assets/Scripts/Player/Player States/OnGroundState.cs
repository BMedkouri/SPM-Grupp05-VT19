using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/OnGroundState")]
public class OnGroundState : PlayerBaseState
{
    // Attributes

    // Methods
    public override void HandleUpdate()
    {
        
        base.HandleUpdate();

        //Transition to RunningState if grounded
        if (owner.IsGrounded())
        {
            owner.Transition<RunningState>();
        }
    }
}
