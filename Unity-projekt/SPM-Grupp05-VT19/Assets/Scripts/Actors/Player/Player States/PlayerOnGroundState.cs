//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerOnGroundState")]
public class PlayerOnGroundState : PlayerBaseState
{
    // Methods
    public override void HandleUpdate()
    {
        // Move to air state if airborne
        if (owner.MovementInput.IsGrounded == false)
        {
            owner.Transition<PlayerInAirState>();
        }

        else
        {
            PlayerInput();
        }

        base.HandleUpdate();
    }
}
