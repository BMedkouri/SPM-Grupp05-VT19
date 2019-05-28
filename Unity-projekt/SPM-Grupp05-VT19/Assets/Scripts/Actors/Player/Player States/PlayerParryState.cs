//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerParryState")]
public class PlayerParryState : PlayerOnGroundState
{
    // Attributes

    [Header("Stamina cost:")]
    [SerializeField] private float staminaExpenditure;

    // Methods
    public override void Enter()
    {
        base.Enter();

        if (owner.CurrentStamina < staminaExpenditure)
        {
            owner.Transition<PlayerOnGroundState>();
        }
        else
        {
            owner.Animator.SetTrigger("Parry");

            owner.CurrentStamina -= staminaExpenditure;
        }
    }

    public override void HandleUpdate()
    {
    }
}
