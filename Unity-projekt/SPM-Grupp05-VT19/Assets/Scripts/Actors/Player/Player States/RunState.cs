//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/RunState")]
public class RunState : OnGroundState
{
    // Attributes


    // Methods
    public override void Enter()
    {
        base.Enter();

        //Enters state run here
       
    }

    public override void HandleUpdate()
    {
        if (Input.GetButtonDown("Xbox X"))
        {
            owner.Transition<PlayerSprintState>();
        }

        if (GetDirection() == Vector3.zero && Vector3.ProjectOnPlane(owner.physics.GetVelocity(), owner.collision.GetGroundRaycastHit().normal) == Vector3.zero)
        {
            owner.Transition<OnGroundState>();
        }

        base.HandleUpdate(); 
    }

    public override void Exit()
    {
        base.Exit();

        //Exits state
    }
}
