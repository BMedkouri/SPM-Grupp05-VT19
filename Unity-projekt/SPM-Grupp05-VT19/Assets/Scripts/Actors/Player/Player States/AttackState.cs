using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/AttackState")]
public class AttackState : PlayerBaseState
{
    // Attributes
    [SerializeField] private float attackSpeed;
    [SerializeField] private float staminaExpenditure;
    private float attackTimer;
    AnimatorClipInfo[] animClip;
    //Attack
    private Animator animator;

    // Methods
    public override void Enter()
    {
        base.Enter();

        if(owner.GetCurrentStamina() < staminaExpenditure)
        {
            owner.Transition<OnGroundState>();
        }
        else
        {
            owner.LoseStamina(staminaExpenditure);

            owner.anim.SetTrigger("Attack1");
            animClip = owner.anim.GetCurrentAnimatorClipInfo(0);
            attackTimer = 0.7f;
            //animClip[0].clip.length;
            //Plays animation
            //animator = GameObject.FindGameObjectWithTag("PlayerWeapon").GetComponentInParent<Animator>();
            //animator.Play("Sword And Shield Slash");
            //Se AnimatorClipInfo för lösning
            //animator.SetFloat("playerAttackSpeed", animator.GetCurrentAnimatorClipInfo(0).Length / attackSpeed);

        }

    }

    public override void HandleUpdate()
    {
        if (attackTimer <= 0)
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

        attackTimer -= Time.deltaTime;
    }
}
