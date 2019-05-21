using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : Leaf
{
    private float timer;
    
    public override NodeStatus OnBehave(BehaviourState state)
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);
        if(timer > 0)
        {
            return NodeStatus.RUNNING;
        }
        else
        {
            return NodeStatus.SUCCESS;

        }
    }

    public override void OnReset()
    {
        timer = 3f;
    }
}
