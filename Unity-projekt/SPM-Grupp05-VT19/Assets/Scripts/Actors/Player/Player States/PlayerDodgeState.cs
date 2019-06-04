//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerDodgeState")]
public class PlayerDodgeState : PlayerOnGroundState
{
    [Header("Stamina cost:")]
    [SerializeField] private float staminaExpenditure;

    #region Methods
    public override void Enter()
    {
        if (owner.CurrentStamina < staminaExpenditure)
        {
            owner.Transition<PlayerOnGroundState>();
        }

        else
        {
            owner.CurrentStamina -= staminaExpenditure;
            owner.Animator.SetTrigger("Roll");
            owner.HealthComponent.IsInvulnerable = true;
        }
    }

    public override void HandleUpdate()
    {
        PlayerRegeneration();
    }

    public override void Exit()
    {
        owner.HealthComponent.IsInvulnerable = false;
    }
    #endregion Methods
}
