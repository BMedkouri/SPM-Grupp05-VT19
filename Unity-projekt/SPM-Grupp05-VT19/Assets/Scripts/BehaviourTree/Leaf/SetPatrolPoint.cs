using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class sets all the points the enemy should patrole between
/// </summary>
public class SetPatrolPoint : Leaf
{
    private Vector3 movePoint;
    public SetPatrolPoint(Vector3 movePoint)
    {
        this.movePoint = movePoint;
    }
    public override NodeStatus OnBehave(BehaviourState state)
    {
        if (movePoint == null)
        {
            return NodeStatus.FAILURE;
        }
        enemy.Agent.SetDestination(movePoint);
        return NodeStatus.SUCCESS;
    }

    public override void OnReset()
    {
    }
}
