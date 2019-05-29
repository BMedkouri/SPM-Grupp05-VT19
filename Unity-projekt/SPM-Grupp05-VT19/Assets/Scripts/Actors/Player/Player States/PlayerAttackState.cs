//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerAttackState")]
public class PlayerAttackState : PlayerBaseState
{
    // Attributes
    [SerializeField] private float attackSpeed;
    [SerializeField] private float staminaExpenditure;
    private string[] attacks = {"Attack", "Attack2", "Attack3", "Attack4"};
    private int index;
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
            index = (index + 1) % attacks.Length;
            owner.Animator.SetTrigger(attacks[index]);
        }
    }
    public override void HandleUpdate(){ }
}
