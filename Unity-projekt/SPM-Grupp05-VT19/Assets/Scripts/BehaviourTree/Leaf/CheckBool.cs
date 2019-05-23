using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBool : Leaf
{
    private bool check;
    public CheckBool(bool check)
    {
        this.check = check;
    }

    public override NodeStatus OnBehave(BehaviourState state)
    {
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
