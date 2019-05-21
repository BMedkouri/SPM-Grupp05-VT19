using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanAttackPlayer : Leaf
{
    private Animator animator;
    private AnimatorClipInfo[] animClip;

    public override NodeStatus OnBehave(BehaviourState state)
    {
        behaviour = (Behaviour)state;
        enemy = behaviour.BehaviourTree;
        if (Player.PlayerReference == null)
            return NodeStatus.FAILURE;

        if (!enemy.CanSeePlayer())
            return NodeStatus.FAILURE;

        //här ska enemys attack spelas upp
        if (Vector3.Distance(enemy.transform.position, Player.PlayerReference.transform.position) < enemy.AttackRange)
        {
            enemy.RotateToTarget(Player.PlayerReference.transform.position);
            //animator.Play("EnemyAttackAnimation");
            return NodeStatus.SUCCESS;
        }

        return NodeStatus.FAILURE;
    }

    public override void OnReset()
    {

    }
}
