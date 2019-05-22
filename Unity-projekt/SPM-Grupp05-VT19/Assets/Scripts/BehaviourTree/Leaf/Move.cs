using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Leaf
{
    
    public override NodeStatus OnBehave(BehaviourState state)
    {
        behaviour = (Behaviour)state;
        enemy = behaviour.BehaviourTree;
        if (enemy.Agent.hasPath == false || Vector3.Distance(enemy.Agent.transform.position, enemy.transform.position) > 60f)
        {
            return NodeStatus.FAILURE;
        }
        else if (Vector3.Distance(enemy.Agent.transform.position, enemy.transform.position) < 3f)
        {
            return NodeStatus.SUCCESS;
        }
        return NodeStatus.RUNNING;

    }

    public override void OnReset()
    {        
    }
    
}
