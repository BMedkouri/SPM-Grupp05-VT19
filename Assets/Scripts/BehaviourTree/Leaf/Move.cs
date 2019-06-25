using UnityEngine;
/*
 * @author Anders Ragnar
 */
public class Move : Leaf
{
    /// <summary>
    /// This state is running as long as the enemy is moving.
    /// </summary>
    /// <param name="state">Behaviour is our connection to the Enemy</param>
    /// <returns>Faliure it the enemy has no path, Success if it is in range and Running if it is moving.</returns>
    public override NodeStatus OnBehave(BehaviourState state)
    {
       
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
        }
        return NodeStatus.RUNNING;

    }

    public override void OnReset()
    {        
    }
    
}
