using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/InAirState")]
public class InAirState : PlayerBaseState
{
    // Attributes


    // Methods
    public override void Enter()
    {
        base.Enter();
    }

    public override void HandleUpdate()
    {
        if (owner.IsGrounded())
        {
            owner.Transition<OnGroundState>();
        }
        base.HandleUpdate();
    }
}
