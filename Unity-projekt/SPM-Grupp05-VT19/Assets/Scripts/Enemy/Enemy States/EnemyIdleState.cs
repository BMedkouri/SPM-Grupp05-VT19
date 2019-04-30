using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/IdleState")]
public class EnemyIdleState : EnemyBaseState
{
    private Vector3[] movePoints;
    private int walkTo;
    public override void Enter()
    {
        movePoints = owner.GetMovePoints();
        foreach(Vector3 mo in movePoints)
        {
            Debug.Log(mo);
        }
        choosClosest();
        base.Enter();
    }
    public override void HandleUpdate()
    {
        owner.agent.SetDestination(movePoints[walkTo]);
        if (Vector3.Distance(owner.transform.position, movePoints[walkTo]) < 3)
        {
            owner.agent.SetDestination(movePoints[walkTo]);
            walkTo = (walkTo + 1) % movePoints.Length;
        }

        if(owner.GetDistance() < 20.0f && owner.CanSeePlayer())
        {
            owner.Transition<EnemyChaseState>();
        }
        base.HandleUpdate();
    }
    private void choosClosest()
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
