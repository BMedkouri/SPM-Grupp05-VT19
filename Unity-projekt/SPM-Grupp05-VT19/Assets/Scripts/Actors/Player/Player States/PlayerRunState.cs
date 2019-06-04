//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerRunState")]
public class PlayerRunState : PlayerOnGroundState
{
    // Methods
    public override void HandleUpdate()
    {
        /*if (Input.GetButtonDown("Xbox X"))
        {
            owner.Transition<PlayerSprintState>();
        }
        else
        {*/
        PlayerMovementInput();
        //}

        base.HandleUpdate();
    }

    protected void PlayerMovementInput()
    {
        owner.MovementInput.UpdateMovementInput();
    }
}
