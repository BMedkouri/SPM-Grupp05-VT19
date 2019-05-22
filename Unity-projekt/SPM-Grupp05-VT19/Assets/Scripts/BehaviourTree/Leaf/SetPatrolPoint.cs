using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class sets all the points the enemy should patrole between
/// </summary>
public class SetPatrolPoint : Leaf
{
    private int walkTo;
    public override NodeStatus OnBehave(BehaviourState state)
    {
        Vector3[] patrolePoints = enemy.PatrolePoints;

        if(patrolePoints == null || patrolePoints.Length == 0)
        {
            return NodeStatus.FAILURE;
        }
        int closest = 0;
        for (int i = 0; i < patrolePoints.Length; i++)
        {
            if (Vector3.Distance(patrolePoints[i], enemy.transform.position) < Vector3.Distance(patrolePoints[closest], enemy.transform.position))
            {
                closest = i;
            }
        }

        walkTo = closest;
        return NodeStatus.SUCCESS;
    }


    public override void OnReset()
    {
    }
}
