using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPatrolPoint : Leaf
{
    private int walkTo;
    public override NodeStatus OnBehave(BehaviourState state)
    {
        behaviour = (Behaviour)state;
        Vector3 enemey = behaviour.EnemyBehaviourTree.transform.position;
        Vector3[] patrolePoints = behaviour.EnemyBehaviourTree.PatrolePoints;

        if(patrolePoints == null || patrolePoints.Length == 0)
        {
            return NodeStatus.FAILURE;
        }
        int closest = 0;
        for (int i = 0; i < patrolePoints.Length; i++)
        {
            if (Vector3.Distance(patrolePoints[i], enemey) < Vector3.Distance(patrolePoints[closest], enemey))
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
