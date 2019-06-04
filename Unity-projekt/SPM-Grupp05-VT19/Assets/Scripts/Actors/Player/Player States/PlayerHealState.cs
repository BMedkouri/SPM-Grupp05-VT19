//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerHealState")]
public class PlayerHealState : PlayerBaseState
{
    // Player is healed via the animation!!!              ***

    public override void Enter()
    {
        owner.Animator.SetTrigger("Heal");
    }

    public override void HandleUpdate()
    {
        PlayerRegeneration();
    }
}
