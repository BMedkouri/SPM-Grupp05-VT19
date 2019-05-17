//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerAttackState")]
public class PlayerAttackState : PlayerBaseState
{
    // Attributes
    [SerializeField] private float attackSpeed;
    [SerializeField] private float staminaExpenditure;
    private float attackTimer;

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
            owner.CurrentStamina -= staminaExpenditure;

            owner.Animator.SetTrigger("SwordAndShieldSlash1");

            attackTimer = 0.7f;
        }

    }

    public override void HandleUpdate()
    {
        if (attackTimer <= 0)
        {
            owner.Transition<PlayerOnGroundState>();
        }

        attackTimer -= Time.deltaTime;
    }
}
