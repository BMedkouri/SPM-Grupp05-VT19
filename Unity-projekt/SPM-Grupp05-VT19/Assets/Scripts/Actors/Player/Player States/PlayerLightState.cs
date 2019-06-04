//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerLightState")]
public class PlayerLightState : PlayerOnGroundState
{
    [Header("Energy Cost")]
    [SerializeField] private float energyExpenditure;

    #region Methods
    public override void Enter()
    {
        if (owner.CurrentEnergy < energyExpenditure)
        {
            owner.Transition<PlayerOnGroundState>();
        }

        else
        {
            owner.CurrentEnergy -= energyExpenditure;
            owner.Animator.SetTrigger("HolyNova");
        }
    }

    public override void HandleUpdate()
    {
        PlayerRegeneration();
    }
    #endregion Methods
}
