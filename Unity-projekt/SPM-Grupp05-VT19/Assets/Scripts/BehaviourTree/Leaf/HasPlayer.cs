using UnityEngine;
using System.Collections;
using System;

public class HasPlayer : Leaf
{
  
    public override NodeStatus OnBehave(BehaviourState state)
    {
        if (Player.PlayerReference == null)
        {
            Debug.Log("Has no Player, in HasPlayer");
            return NodeStatus.FAILURE;
        }
        return NodeStatus.SUCCESS;
    }

    public override void OnReset()
    {
    }
}
