using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Behaviour : BehaviourState
{
    public EnemyBehaviourTree EnemyBehaviourTree { get; private set; }

    public Behaviour(EnemyBehaviourTree enemyBehaviourTree)
    {
        EnemyBehaviourTree = enemyBehaviourTree;
    }

}
