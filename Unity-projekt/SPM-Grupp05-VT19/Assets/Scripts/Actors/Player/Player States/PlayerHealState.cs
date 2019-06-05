//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerHealState")]
public class PlayerHealState : PlayerBaseState
{
    // Player is healed via the animation!!!              ***

    [Header("Energy Cost")]
    [SerializeField] private float energyExpenditure;

    public override void Enter()
    {
        if (owner.CurrentEnergy < energyExpenditure)
        {
            owner.Transition<PlayerOnGroundState>();
        }

        else
        {
            owner.CurrentEnergy -= energyExpenditure;
            owner.Animator.SetTrigger("Heal");
        }
    }

    public override void HandleUpdate()
    {
        PlayerRegeneration();
    }
}
