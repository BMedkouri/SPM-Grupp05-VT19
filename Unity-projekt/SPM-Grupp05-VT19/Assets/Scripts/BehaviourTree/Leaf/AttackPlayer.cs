using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : Leaf
{
    private Animator animator;
    AnimatorClipInfo[] animClip;

    public override NodeStatus OnBehave(BehaviourState state)
    {
        behaviour = (Behaviour)state;
        EnemyBehaviourTree enemy = behaviour.EnemyBehaviourTree;

        if (Player.PlayerReference == null)
            return NodeStatus.FAILURE;

        if (!enemy.CanSeePlayer())
            return NodeStatus.FAILURE;
        if (Vector3.Distance(enemy.transform.position, Player.PlayerReference.transform.position) > enemy.AttackRange)
            return NodeStatus.FAILURE;

        //här ska enemys attack spelas upp
        if (Vector3.Distance(enemy.transform.position, Player.PlayerReference.transform.position) < enemy.AttackRange)
        {
            //animator.Play("EnemyAttackAnimation");
            Debug.Log("Attacking");
            return NodeStatus.SUCCESS;
        }

        return NodeStatus.FAILURE;
    }


    public override void OnReset()
    {
    }
}
