//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using UnityEngine;

public class PlayerBaseState : State
{
    protected Player owner;

    #region Methods
    public override void Initialize(StateMachine owner)
    {
        this.owner = (Player)owner;
    }

    public override void HandleUpdate()
    {
        PlayerRegeneration(); // Stamina and energy only.

        // TEST:
        PlayerMovementInput();
    }

    protected void PlayerRegeneration()
    {
        owner.Regeneration();
    }

    protected void PlayerInput()
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

    protected void PlayerMovementInput()
    {
        owner.MovementInput.UpdateMovementInput();
    }
    #endregion Methods
}
