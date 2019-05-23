using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class sets all the points the enemy should patrole between
/// </summary>
public class SetPatrolPoint : Leaf
{
    private Vector3[] movePoints;
    public SetPatrolPoint(params Vector3[] movePoints)
    {
        this.movePoints = movePoints;
    }
    private int walkTo;
    public override NodeStatus OnBehave(BehaviourState state)
    {
        if (movePoints == null || movePoints.Length == 0)
        {
            return NodeStatus.FAILURE;
        };
        if (Vector3.Distance(enemy.transform.position, movePoints[walkTo]) < 3f)
        {
            walkTo = (walkTo + 1) % movePoints.Length;
        }

        enemy.Agent.SetDestination(movePoints[walkTo]);
        return NodeStatus.SUCCESS;
    }

    public override void OnReset()
    {
    }
}
