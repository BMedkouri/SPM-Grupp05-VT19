//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerAttackState")]
public class PlayerAttackState : PlayerBaseState
{
    // Attributes
    [SerializeField] private float attackSpeed;
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
            owner.Animator.SetTrigger("SwordAndShieldSlash1");

            owner.CurrentStamina -= staminaExpenditure;
            
        }

    }

    public override void HandleUpdate(){ }
}
