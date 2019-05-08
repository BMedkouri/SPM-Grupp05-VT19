using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerLightState")]
public class PlayerLightState : OnGroundState
{
    [SerializeField] private float energyExpenditure; // Energy cost
    
    private float clipTimer;
    AnimatorClipInfo[] animClip;
    
    public override void Enter()
    {
        base.Enter();

        if(owner.GetCurrentEnergy() < energyExpenditure)
        {
            owner.Transition<OnGroundState>();
        }
        else
        {
            owner.LoseEnergy(energyExpenditure);

            owner.animator.SetTrigger("HolyNova");
            owner.GetComponentInChildren<AttackHandler>().SetAttackName("HolyNova");
            //animClip = owner.anim.GetCurrentAnimatorClipInfo(0);
            clipTimer = 2f; 
            //animClip[0].clip.length;
        }
    }
    public override void HandleUpdate()
    {
        if (clipTimer <= 0)
        {
            if (owner.collision.IsGrounded())
            {
                owner.Transition<OnGroundState>();
            }
            else
            {
                owner.Transition<InAirState>();
            }
        }

        clipTimer -= Time.deltaTime;
    }
}
