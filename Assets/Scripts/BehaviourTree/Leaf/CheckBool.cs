using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Checks if the the enemy can do it's dark attack
/// </summary>
public class CheckBool : Leaf
{
   
    public override NodeStatus OnBehave(BehaviourState state)
    {
        if (enemy.CanDoDarkAttack  == true)
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
