using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : Leaf
{
    private float attackTimer, countDown;
    public AttackPlayer(float attackTimer)
    {
        this.attackTimer = attackTimer;
    }
    public override NodeStatus OnBehave(BehaviourState state)
    {
        
        behaviour = (Behaviour)state;
        enemy = behaviour.BehaviourTree;
        
        if (Player.PlayerReference == null)
            return NodeStatus.FAILURE;

        if (!enemy.CanSeePlayer())
            return NodeStatus.FAILURE;
        if (Vector3.Distance(enemy.transform.position, Player.PlayerReference.transform.position) > enemy.AttackRange)
            return NodeStatus.FAILURE;

        enemy.RotateToTarget(Player.PlayerReference.transform.position);

        //här ska enemys attack spelas upp
        if (Vector3.Distance(enemy.transform.position, Player.PlayerReference.transform.position) < enemy.AttackRange && attackTimer <= 0)
        {
            enemy.Animator.SetTrigger("Attack");
            //animator.Play("EnemyAttackAnimation");
            return NodeStatus.SUCCESS;
        }
        attackTimer -= Time.deltaTime;
        return NodeStatus.RUNNING;
    }


    public override void OnReset()
    {
        countDown = attackTimer;
    }
}
