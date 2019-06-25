using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// this class checks if the enemy moves towraeds the player,
/// if there is no path the class returns Faliure, still moving it returns Running
/// and if it arrived it returns Success
/// </summary>
public class MoveToPlayer : Leaf
{
    Vector3 origin;
    public MoveToPlayer(Vector3 origin)
    {
        this.origin = origin;
    }
    public override NodeStatus OnBehave(BehaviourState state)
    {
        enemy.Agent.SetDestination(Player.PlayerReference.transform.position);
        if (enemy.Agent.hasPath == false)
        {
            return NodeStatus.FAILURE;
        }
        else if (Vector3.Distance(enemy.Agent.transform.position, enemy.Agent.destination) < 3f)
        {
            return NodeStatus.SUCCESS;
        }
        else if (enemy.Agent.destination == Player.PlayerReference.transform.position && enemy.CanSeePlayer() && Vector3.Distance(enemy.transform.position, Player.PlayerReference.transform.position) < enemy.ChaseRange)
        {
            return NodeStatus.FAILURE;
        }else if(enemy.CanSeePlayer() == false)
        {
            return NodeStatus.FAILURE;
        }
        return NodeStatus.RUNNING;
    }

    public override void OnReset()
    {
    }

    
}
