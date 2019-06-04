/*
 * @author Anders Ragnar
 */

using UnityEngine;
/// <summary>
/// just a class that checks if the enemy can see the player
/// </summary>
public class CanSeePlayer : Leaf
{
    public override NodeStatus OnBehave(BehaviourState state)
    {
        if (enemy.CanSeePlayer()){
            return NodeStatus.SUCCESS;
        }
        return NodeStatus.FAILURE;
    }

    public override void OnReset()
    {
    }
    
}
