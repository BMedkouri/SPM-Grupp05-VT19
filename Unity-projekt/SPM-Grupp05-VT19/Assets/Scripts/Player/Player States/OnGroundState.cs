using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/OnGroundState")]
public class OnGroundState : PlayerBaseState
{
    // Attributes
    [SerializeField] private float jumpStaminaExpenditure; // Stamina cost for jumping
    
    // Methods
    public override void Enter()
    {
        base.Enter();
    }

    public override void HandleUpdate()
    {
        //Change this later!   
	    //Transition to RunningState if grounded
        if (owner.collision.IsGrounded() && owner.GetCurrentState().ToString().Equals("OnGroundState(Clone) (OnGroundState)") && GetDirection() != Vector3.zero)
        {
            owner.Transition<RunState>();
        }

        //Jumping and transitioning to InAirState
        if (Input.GetKeyDown(KeyCode.Space) && owner.collision.IsGrounded())
        {
            if (owner.GetCurrentStamina() >= jumpStaminaExpenditure)
            {
                owner.LoseStamina(jumpStaminaExpenditure);
                owner.physics.Jump(jumpHeight);
                owner.Transition<InAirState>();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            owner.Transition<PlayerDodgeState>();
        }

        base.HandleUpdate();
    }

}
