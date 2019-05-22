using UnityEngine;
/*
 * @author Anders Ragnar
 */
public class HasPlayer : Leaf
{
    /// <summary>
    /// Checks if there are any player in the game
    /// </summary>
    /// <param name="state">refference to the enemy</param>
    /// <returns>Failure if there is no player</returns>
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
