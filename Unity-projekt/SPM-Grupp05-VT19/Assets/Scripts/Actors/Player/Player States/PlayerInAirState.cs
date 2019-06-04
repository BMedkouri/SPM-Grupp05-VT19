//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerInAirState")]
public class PlayerInAirState : PlayerBaseState
{
    // Methods
    public override void HandleUpdate()
    {
        if (owner.MovementInput.IsGrounded == true)
        {
            owner.Transition<PlayerOnGroundState>();
        }

        owner.MovementInput.UpdateMovementInput();

        base.HandleUpdate();
    }
}
