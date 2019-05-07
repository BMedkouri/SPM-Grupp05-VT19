using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/EnemyAttackState")]
public class EnemyAttackState : EnemyCombatState
{
    private Animator anim;
    private float clipTimer;
    AnimatorClipInfo[] animClip;

    public override void Enter()
    {
        anim = owner.GetComponentInChildren<Animator>();
        anim.Play("EnemyAttackAnimation");
        clipTimer = 1f;
//anim.GetCurrentAnimatorClipInfo(0).Length;
        base.Enter();
    }
    public override void HandleUpdate()
    {
        
        if(clipTimer <= 0)
        {

            clipTimer = anim.GetCurrentAnimatorClipInfo(0).Length;

            owner.Transition<EnemyCombatState>();
        }
        countDown();
    }
    public void countDown()
    {
        clipTimer -= Time.deltaTime;
    }
}
