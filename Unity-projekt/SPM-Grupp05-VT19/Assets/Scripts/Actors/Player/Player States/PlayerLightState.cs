//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerLightState")]
public class PlayerLightState : PlayerOnGroundState
{
    //Attributes

    [Header("Energy Cost:")]
    [SerializeField] private float energyExpenditure;

    // Animation 
    private float clipTimer;

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

            // TODO: Fetch animation length and set clipTimer to that!
            clipTimer = 2f;
        }
    }

    public override void HandleUpdate()
    {
        if (clipTimer <= 0)
        {
            owner.Transition<PlayerOnGroundState>();
        }

        clipTimer -= Time.deltaTime;
    }
}
