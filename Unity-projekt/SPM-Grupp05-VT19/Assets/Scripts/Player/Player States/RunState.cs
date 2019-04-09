using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/RunState")]
public class RunState : OnGroundState
{
    // Attributes


    // Methods
    public override void HandleUpdate()
    {
        base.HandleUpdate();

        //Jumping and transitioning to InAirState
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (owner.IsGrounded())
            {
                owner.physics.Jump(jumpHeight);
                owner.Transition<InAirState>();
            }
        }
    }
}
