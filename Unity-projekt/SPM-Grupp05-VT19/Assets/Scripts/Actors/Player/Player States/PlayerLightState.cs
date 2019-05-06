using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerLightState")]
public class PlayerLightState : OnGroundState
{
    [SerializeField] private float energyExpenditure; // Energy cost

    private Animator anim;
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

            anim = GameObject.FindGameObjectWithTag("Cross").GetComponent<Animator>();

            anim.Play("PlayerLightAnimation");

            animClip = this.anim.GetCurrentAnimatorClipInfo(0);

            clipTimer = 1f;
            //clipTimer = animClip[0].clip.length;
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
