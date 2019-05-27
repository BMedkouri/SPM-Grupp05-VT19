using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistanceToOrigin : Leaf
{
    Vector3 movePoint;
    public CheckDistanceToOrigin(Vector3 origin)
    {
        
        movePoint = origin;
    }

    public override NodeStatus OnBehave(BehaviourState state)
    {
        if (Vector3.Distance(movePoint, enemy.transform.position) > 60)
        {
            return NodeStatus.SUCCESS;

        }
        return NodeStatus.FAILURE;
    }

    public override void OnReset()
    {
    }
}
