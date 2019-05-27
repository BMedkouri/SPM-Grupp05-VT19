using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBool : Leaf
{
    private bool check;
   
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
