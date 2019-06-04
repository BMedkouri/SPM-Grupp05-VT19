using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackTimer : Leaf
{
    private float time;
    private float countDown;
    public BossAttackTimer(float setTimer)
    {
        time = setTimer;
        //countDown = time;
    }

    public override NodeStatus OnBehave(BehaviourState state)
    {
        if (Player.PlayerReference == null)
            return NodeStatus.FAILURE;
        if (!enemy.CanSeePlayer())
            return NodeStatus.FAILURE;
        if (Vector3.Distance(enemy.transform.position, Player.PlayerReference.transform.position) > enemy.AttackRange)
            return NodeStatus.FAILURE;

        enemy.RotateToTarget(Player.PlayerReference.transform.position);
        
        countDown -= Time.deltaTime;
        Debug.Log(countDown);
        if (countDown > 0)
        {
            return NodeStatus.RUNNING;
        }
        else if (countDown <= 0)
        {
            countDown = time;
            return NodeStatus.SUCCESS;
        }
        return NodeStatus.FAILURE;
    }

    public override void OnReset()
    {
        
    }
}
