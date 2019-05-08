using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @author Anders Ragnar
 * @co-author Bilal El Medkouri
 * 
 * This class tells the Enemy/object what to do when it does not try to attack or chase the player
 */
[CreateAssetMenu(menuName = "Enemy States/IdleState")]
public class EnemyIdleState : EnemyBaseState
{
    private Vector3[] movePoints;
    private int walkTo;

    /// <summary>
    /// When this state is initialized the enemy choses what point it should patrole to, if there are any points
    /// </summary>
    public override void Enter()
    {
        movePoints = owner.GetMovePoints();
        ChooseClosest();
        base.Enter();
    }

    /// <summary>
    /// This method makes the enemy walk to the closest patrolepoint, if it is in 3 meters it choses the next point.
    /// It also checks if the player is in the reatch of start chasing.
    /// </summary>
    public override void HandleUpdate()
    {
        if(movePoints.Length > 0)
        {
            owner.agent.SetDestination(movePoints[walkTo]);
            if (Vector3.Distance(owner.transform.position, movePoints[walkTo]) < 3f)
            {
                owner.agent.SetDestination(movePoints[walkTo]);
                walkTo = (walkTo + 1) % movePoints.Length;
            }
        }

        if (owner.GetDistance() < 20.0f && owner.CanSeePlayer())
        {
            owner.Transition<EnemyChaseState>();
        }

        base.HandleUpdate();
    }

    /// <summary>
    /// This method chooses the closest patrolepoint to move to.
    /// </summary>
    private void ChooseClosest()
    {
        int closest = 0;
        for(int i = 0; i < movePoints.Length; i++)
        {
            if(Vector3.Distance(movePoints[i], owner.transform.position) < Vector3.Distance(movePoints[closest], owner.transform.position))
            {
                closest = i;
            }
        }

        walkTo = closest;
    }
}
