//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerLightState")]
public class PlayerLightState : PlayerOnGroundState
{
    //Attributes

    [Header("Energy Cost:")]
    [SerializeField] private float energyExpenditure;
    
    // Methods
    public override void Enter()
    {
        base.Enter();

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
    }
}
