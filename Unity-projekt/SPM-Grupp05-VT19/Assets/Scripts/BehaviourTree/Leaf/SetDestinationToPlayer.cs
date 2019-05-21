using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDestinationToPlayer : Leaf
{
   
    public override NodeStatus OnBehave(BehaviourState state)
    {
        behaviour = (Behaviour)state;
        enemy = behaviour.BehaviourTree;
        enemy.Agent.SetDestination(Player.PlayerReference.transform.position);
        if (behaviour.BehaviourTree.Agent.hasPath == false)
        {
            return NodeStatus.FAILURE;
        }
        return NodeStatus.SUCCESS;
    }

    public override void OnReset()
    {
    }
}
