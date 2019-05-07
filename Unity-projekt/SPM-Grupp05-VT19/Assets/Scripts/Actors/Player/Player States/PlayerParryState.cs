using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerParryState")]
public class PlayerParryState : OnGroundState
{
    [SerializeField] private float staminaExpenditure;  // Stamina cost

    //private Animator anim;
    private float clipTimer;
    AnimatorClipInfo[] animClip;

    public override void Enter()
    {
        base.Enter();

        if (owner.GetCurrentStamina() < staminaExpenditure)
        {
            owner.Transition<OnGroundState>();
        }
        else
        {
            owner.anim.SetTrigger("Block");
            owner.LoseStamina(staminaExpenditure);
            animClip = owner.anim.GetCurrentAnimatorClipInfo(0);
            clipTimer = 0.5f;
                //animClip[0].clip.length;
            
        }
    }
    public override void HandleUpdate()
    {
        if (clipTimer <= 0)
        {
            clipTimer = owner.anim.GetCurrentAnimatorClipInfo(0).Length;
            owner.Transition<OnGroundState>();
        }

        clipTimer -= Time.deltaTime;
    }
}
