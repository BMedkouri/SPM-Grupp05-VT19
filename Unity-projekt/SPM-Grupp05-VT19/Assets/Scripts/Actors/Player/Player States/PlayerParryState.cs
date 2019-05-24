//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerParryState")]
public class PlayerParryState : PlayerOnGroundState
{
    // Attributes

    [Header("Stamina cost:")]
    [SerializeField] private float staminaExpenditure;

    private float clipTimer;

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
            owner.Animator.SetTrigger("Block");

            owner.CurrentStamina -= staminaExpenditure;

            clipTimer = 0.5f; // TODO: Replace this with clip length!

        }
    }

    public override void HandleUpdate()
    {
        //if (clipTimer <= 0)
        //{
        //    clipTimer = owner.Animator.GetCurrentAnimatorClipInfo(0).Length;
        //    owner.Transition<PlayerOnGroundState>();
        //}

        //clipTimer -= Time.deltaTime;
    }
}
