﻿using UnityEngine;
/*
 * @author Anders Ragnar
 */
public class CanAttackPlayer : Leaf
{
    /// <summary>
    /// This state checks if it can attack the enemy
    /// </summary>
    /// <param name="state">Behaviour is our connection to the Enemy</param>
    /// <returns>Failure if it can't preforme this behaviour, Running if it is preforming and Success if it has preformed it</returns>
    public override NodeStatus OnBehave(BehaviourState state)
    {
        Debug.Log("can atack player");
        if (Player.PlayerReference == null)
            return NodeStatus.FAILURE;

        if (!enemy.CanSeePlayer())
            return NodeStatus.FAILURE;

        //här ska enemys attack spelas upp
        if (Vector3.Distance(enemy.transform.position, Player.PlayerReference.transform.position) < enemy.AttackRange)
        {
            Debug.Log("success");
            enemy.RotateToTarget(Player.PlayerReference.transform.position);
            //animator.Play("EnemyAttackAnimation");
            return NodeStatus.SUCCESS;
        }
        Debug.Log("AttackRange: " + enemy.AttackRange);
        Debug.Log("Distance: " + Vector3.Distance(enemy.transform.position, Player.PlayerReference.transform.position));
        Debug.Log("failure");

        return NodeStatus.FAILURE;
    }

    public override void OnReset()
    {

    }
}
