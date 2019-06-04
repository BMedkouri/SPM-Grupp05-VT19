//Author: Anders Ragnar

using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/EnemyChaseState")]
public class EnemyChaseState : EnemyBaseState
{
    public override void Enter()
    {
        base.Enter();
    }

    /// <summary>
    /// This methods uses Unitys own navmeshagent to follow the player.
    /// The first if statsment checks if the object can see the player and if its to far to chase,
    /// The second if statment checks if the object is so close that the object can hit the player
    /// </summary>
    public override void HandleUpdate()
    {

        owner.Agent.SetDestination(Player.Instance.transform.position);

        if (owner.GetDistance() > 20.0f || !owner.CanSeePlayer())
        {
            owner.Transition<EnemyIdleState>();
        }

        if (owner.GetDistance() < owner.Agent.stoppingDistance && owner.CanSeePlayer())
        {
            owner.Agent.acceleration = 60f;
            owner.Transition<EnemyCombatState>();
        }

        base.HandleUpdate();
    }
}
