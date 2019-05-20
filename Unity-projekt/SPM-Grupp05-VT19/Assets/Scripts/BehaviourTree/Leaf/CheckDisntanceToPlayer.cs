using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDisntanceToPlayer : Leaf
{
    private float range;
    public CheckDisntanceToPlayer(float range)
    {
        this.range = range;
    }
    public override NodeStatus OnBehave(BehaviourState state)
    {
        behaviour = (Behaviour)state;
        EnemyBehaviourTree enemy = behaviour.EnemyBehaviourTree;
        if (Vector3.Distance(enemy.transform.position, Player.PlayerReference.transform.position) < range)
        {
            return NodeStatus.SUCCESS;
        }
        else
        {
            return NodeStatus.FAILURE;
        }
    }

    public override void OnReset()
    {

    }
}
