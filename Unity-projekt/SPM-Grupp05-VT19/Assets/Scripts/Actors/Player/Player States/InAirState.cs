using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/InAirState")]
public class InAirState : PlayerBaseState
{
    // Attributes


    // Methods
    public override void HandleUpdate()
    {
        //Debug.Log("jumpState");
        if (owner.collision.IsGrounded())
        {
            owner.Transition<OnGroundState>();
        }

        base.HandleUpdate();
    }
}
