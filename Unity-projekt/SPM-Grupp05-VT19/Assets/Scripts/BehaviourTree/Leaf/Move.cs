using UnityEngine;
/*
 * @author Anders Ragnar
 */
public class Move : Leaf
{
    /// <summary>
    /// This state is running as long as the enemy is running
    /// </summary>
    /// <param name="state">Behaviour is our connection to the Enemy</param>
    /// <returns>Failure if it can't preforme this behaviour, Running if it is preforming and Success if it has preformed it</returns>
    public override NodeStatus OnBehave(BehaviourState state)
    {
        if (enemy.Agent.hasPath == false || Vector3.Distance(enemy.Agent.transform.position, enemy.transform.position) > 60f)
        {
            return NodeStatus.FAILURE;
        }
        else if (Vector3.Distance(enemy.Agent.transform.position, enemy.transform.position) < 3f)
        {
            return NodeStatus.SUCCESS;
        }
        return NodeStatus.RUNNING;

    }

    public override void OnReset()
    {        
    }
    
}
