using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundState : PlayerBaseState
{
    // Attributes

    // Methods
    public override void Enter()
    {
        base.Enter();
    }

    public override void HandleUpdate()
    {
        
        base.HandleUpdate();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!owner.IsGrounded())
            {
                physics.Jump(jumpHeight);
                owner.Transition<InAirState>();
            }
        }
    }
}
