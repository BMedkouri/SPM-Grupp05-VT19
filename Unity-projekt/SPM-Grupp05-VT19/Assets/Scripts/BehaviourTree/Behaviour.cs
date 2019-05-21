using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Behaviour : BehaviourState
{
    public BehaviourTree BehaviourTree { get; private set; }
    
    public Behaviour(BehaviourTree behaviourTree)
    {
        BehaviourTree = behaviourTree;
    }
}
