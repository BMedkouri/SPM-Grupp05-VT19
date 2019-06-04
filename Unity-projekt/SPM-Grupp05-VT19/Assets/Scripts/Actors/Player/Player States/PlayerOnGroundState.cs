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

    private void PlayerInput()
    {
        // TODO: Remove temporary if-cases
        #region Temporary
        // Heal player - Temporary
        if (Input.GetKeyDown(KeyCode.K))
        {
            owner.HealthComponent.CurrentHealth += 30.0f;
            owner.CurrentStamina += 15.0f;
            owner.CurrentEnergy += 10.0f;
        }

        // Move player 5m up - Temporary
        if (Input.GetKeyDown(KeyCode.V))
        {
            owner.transform.position += Vector3.up * 5f;
        }

        // Reset save file - Temporary
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.ResetPlayerPrefs();
        }
        #endregion Temporary

        if (Input.GetAxisRaw("Right Trigger") == 1)
        {
            owner.Transition<PlayerAttackState>();
        }

        else if (Input.GetAxisRaw("Left Trigger") == 1)
        {
            owner.Transition<PlayerParryState>();
        }

        else if (Input.GetButtonDown("Left Bumper"))
        {
            owner.Transition<PlayerLightState>();
        }

        else if (Input.GetButton("Xbox Y"))
        {
            owner.Transition<PlayerHealState>();
        }

        else if (Input.GetButton("Xbox B"))
        {
            owner.Transition<PlayerDodgeState>();
        }

        else
        {
            owner.Transition<PlayerRunState>();
        }
    }
}
