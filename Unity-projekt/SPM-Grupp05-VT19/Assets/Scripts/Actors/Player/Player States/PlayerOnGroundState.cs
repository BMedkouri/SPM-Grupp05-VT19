//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerOnGroundState")]
public class PlayerOnGroundState : PlayerBaseState
{
    // Methods
    public override void Enter()
    {
        base.Enter();
    }

    public override void HandleUpdate()
    {
        // TODO: Change this later!   
        //Transition to RunningState if grounded
        if (owner.Collision.IsGrounded == true && owner.GetCurrentState().ToString().Equals("PlayerOnGroundState(Clone) (PlayerOnGroundState)") 
            && GetDirection() != Vector3.zero)
        {
            owner.Transition<PlayerRunState>();
        }

        if (Input.GetButton("Xbox Y"))
        {
            owner.Transition<PlayerHealState>();
        }

        else if (Input.GetButton("Xbox B"))
        {
            owner.Transition<PlayerDodgeState>();
        }

        base.HandleUpdate();
    }

}
