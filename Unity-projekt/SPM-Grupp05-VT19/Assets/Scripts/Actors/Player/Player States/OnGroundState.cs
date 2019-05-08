//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Bilal El Medkouri
 * @co-author Anders Ragnar
 */
[CreateAssetMenu(menuName = "Player States/OnGroundState")]
public class OnGroundState : PlayerBaseState
{
    // Attributes
    
    // Methods
    public override void Enter()
    {
        base.Enter();
    }
    /// <summary>
    /// Checks if the player is grounded, if it heals and if it is trying to dodge, then transitions to it.
    /// </summary>
    public override void HandleUpdate()
    {
        //Change this later!   
	    //Transition to RunningState if grounded
        if (owner.collision.IsGrounded() && owner.GetCurrentState().ToString().Equals("OnGroundState(Clone) (OnGroundState)") && GetDirection() != Vector3.zero)
        {
            owner.Transition<RunState>();
        }

        if (Input.GetButton("Xbox Y"))
        {
            //owner.Transition<PlayerHealState>();
        }

        if (Input.GetButton("Xbox B"))
        {
            owner.Transition<PlayerDodgeState>();
        }

        base.HandleUpdate();
    }

}
