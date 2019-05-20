using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSeePlayer : Leaf
{
    public override NodeStatus OnBehave(BehaviourState state)
    {
        EnemyBehaviourTree enemy = behaviour.EnemyBehaviourTree;
        if (!Physics.Linecast(enemy.transform.position, Player.PlayerReference.transform.position, LayerMask.GetMask("Geomitry"))){
            return NodeStatus.SUCCESS;
        }
        return NodeStatus.FAILURE;
    }

    public override void OnReset()
    {
    }
    
}
