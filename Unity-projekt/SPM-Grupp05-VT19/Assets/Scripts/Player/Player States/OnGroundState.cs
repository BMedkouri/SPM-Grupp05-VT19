using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/OnGroundState")]
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
        //Change this later!   
	    //Transition to RunningState if grounded
        if (owner.collision.IsGrounded() && owner.GetCurrentState().ToString().Equals("OnGroundState(Clone) (OnGroundState)") && GetDirection() != Vector3.zero)
        {
            owner.Transition<RunState>();
        }

        if (Input.GetButton("Xbox B"))
        {
            owner.Transition<PlayerDodgeState>();
        }

        base.HandleUpdate();
    }

}
