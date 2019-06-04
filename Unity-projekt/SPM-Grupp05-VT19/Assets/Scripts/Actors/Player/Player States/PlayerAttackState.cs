//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerAttackState")]
public class PlayerAttackState : PlayerBaseState
{
    #region Variables

    [Header("Stamina cost")]
    [SerializeField] private float staminaExpenditure;

    private string[] attacks = { "Attack", "Attack2", "Attack3", "Attack4" };
    private int attackIndex;

    #endregion Variables

    #region Methods

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
            attackIndex = Random.Range(0, attacks.Length);
            owner.Animator.SetTrigger(attacks[attackIndex]);
        }
    }

    public override void HandleUpdate()
    {
        PlayerRegeneration();
    }

    #endregion Methods
}
