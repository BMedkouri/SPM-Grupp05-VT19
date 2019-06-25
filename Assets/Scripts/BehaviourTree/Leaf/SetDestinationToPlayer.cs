using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Set the destination to the Player
/// </summary>
public class SetDestinationToPlayer : Leaf
{
   
    public override NodeStatus OnBehave(BehaviourState state)
    {
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
