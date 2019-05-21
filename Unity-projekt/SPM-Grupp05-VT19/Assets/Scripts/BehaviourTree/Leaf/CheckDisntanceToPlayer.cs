using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDisntanceToPlayer : Leaf
{
    
    private float range;
    public CheckDisntanceToPlayer(float range)
    {
        this.range = range;
    }
    public override NodeStatus OnBehave(BehaviourState state)
    {
        //det här bör göras när den instansieras men hittar inget bra sätt, får ta tag i det senare dock
        behaviour = (Behaviour)state;
        enemy = behaviour.BehaviourTree;
        if (Vector3.Distance(enemy.transform.position, Player.PlayerReference.transform.position) < range)
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
