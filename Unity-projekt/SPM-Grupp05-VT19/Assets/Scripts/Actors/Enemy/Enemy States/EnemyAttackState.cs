using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @autor Anders Ragnar
 * @co-author Bilal El Medkouri
 */
[CreateAssetMenu(menuName = "Enemy States/EnemyAttackState")]
public class EnemyAttackState : EnemyCombatState
{
    private Animator anim;
    private float clipTimer;
    AnimatorClipInfo[] animClip;

    /// <summary>
    /// Gets the animation and plays it.
    /// </summary>
    public override void Enter()
    {
        anim = owner.GetComponentInChildren<Animator>();
        anim.Play("EnemyAttackAnimation");
        clipTimer = 1f;
//anim.GetCurrentAnimatorClipInfo(0).Length;
        base.Enter();
    }

    /// <summary>
    /// Counts down so you can't do other this at the same time as you attack.
    /// That's why it is missing base.HandelUpdate();.
    /// </summary>
    public override void HandleUpdate()
    {
        
        if(clipTimer <= 0)
        {

            clipTimer = anim.GetCurrentAnimatorClipInfo(0).Length;

            owner.Transition<EnemyCombatState>();
        }
        clipTimer -= Time.deltaTime;
    }
}
