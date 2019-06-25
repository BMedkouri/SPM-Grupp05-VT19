using UnityEngine;
/*
 * @author Anders Ragnar
 */
public class CanAttackPlayer : Leaf
{
    /// <summary>
    /// This states checks if the enemy is in attackrange of the player
    /// </summary>
    /// <param name="state">Behaviour is our connection to the Enemy</param>
    /// <returns>Failure if it can't preforme this behaviour, Running if it is preforming and Success if it has preformed it</returns>
    public override NodeStatus OnBehave(BehaviourState state)
    {
        if (Player.PlayerReference == null)
            return NodeStatus.FAILURE;

        if (!enemy.CanSeePlayer())
            return NodeStatus.FAILURE;
        
        if (Vector3.Distance(enemy.transform.position, Player.PlayerReference.transform.position) < enemy.AttackRange)
        {
            enemy.RotateToTarget(Player.PlayerReference.transform.position);
            return NodeStatus.SUCCESS;
        }

        return NodeStatus.FAILURE;
    }

    public override void OnReset()
    {

    }
}
