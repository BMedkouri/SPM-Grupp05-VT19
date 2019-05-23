using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBool : Leaf
{
    private bool check;
   
    public override NodeStatus OnBehave(BehaviourState state)
    {
        check = enemy.GetComponent<BossBehaviourTree>().CanDoDarkAttack;
        if(check == true)
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
