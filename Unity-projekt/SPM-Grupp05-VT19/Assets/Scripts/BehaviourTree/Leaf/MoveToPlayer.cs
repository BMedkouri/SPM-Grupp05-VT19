using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : Leaf
{
    Vector3 origin;
    public MoveToPlayer(Vector3 origin)
    {
        this.origin = origin;
    }
    public override NodeStatus OnBehave(BehaviourState state)
    {
        enemy.Agent.SetDestination(Player.Instance.transform.position);
        if (enemy.Agent.hasPath == false)
        {
            return NodeStatus.FAILURE;
        }
        else if (Vector3.Distance(enemy.Agent.transform.position, enemy.Agent.destination) < 3f)
        {
            return NodeStatus.SUCCESS;
        }
        else if (enemy.Agent.destination == Player.Instance.transform.position && enemy.CanSeePlayer() && Vector3.Distance(enemy.transform.position, Player.Instance.transform.position) < enemy.ChaseRange)
        {
            return NodeStatus.FAILURE;
        }else if(enemy.CanSeePlayer() == false)
        {
            return NodeStatus.FAILURE;
        }
        return NodeStatus.RUNNING;
    }

    public override void OnReset()
    {
    }

    
}
