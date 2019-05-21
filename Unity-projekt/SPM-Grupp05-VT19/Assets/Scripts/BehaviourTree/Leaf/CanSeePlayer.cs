﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSeePlayer : Leaf
{
    public override NodeStatus OnBehave(BehaviourState state)
    {
        behaviour = (Behaviour)state;
        enemy = behaviour.BehaviourTree;
        if (enemy.CanSeePlayer()){
            return NodeStatus.SUCCESS;
        }
        return NodeStatus.FAILURE;
    }

    public override void OnReset()
    {
    }
    
}
