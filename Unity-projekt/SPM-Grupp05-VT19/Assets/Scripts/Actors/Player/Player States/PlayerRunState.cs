//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerRunState")]
public class PlayerRunState : PlayerOnGroundState
{
    // Methods
    public override void Enter()
    {
        base.Enter();

        //Enters state run here
       
    }

    public override void HandleUpdate()
    {
        //if (Input.GetButtonDown("Xbox X"))
        //{
        //    owner.Transition<PlayerSprintState>();
        //}

        if (GetDirection() == Vector3.zero && Vector3.ProjectOnPlane(owner.Physics.Velocity, owner.Collision.GetGroundRaycastHit().normal) == Vector3.zero)
        {
            owner.Transition<PlayerOnGroundState>();
        }

        base.HandleUpdate(); 
    }

    public override void Exit()
    {
        base.Exit();

      
        //Exits state
    }
}
