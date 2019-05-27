﻿using UnityEngine;
/*
 * @author Anders Ragnar
 */

/// <summary>
/// should be a timer that is for all other behaviours aswell.
/// the timer should be set in the constructor and not be hardcoded like this.
/// </summary>
public class Timer : Leaf
{
    private float time;
    private float countDown;
    public Timer(float setTimer)
    {
        time = setTimer;
        countDown = time;
    }
    public override NodeStatus OnBehave(BehaviourState state)
    {
        countDown -= Time.deltaTime;
        if (enemy.CanDoDarkAttack == false)
        {
            enemy.GetComponent<BossBehaviourTree>().StartResetBool();
            return NodeStatus.FAILURE;
        }
        else if (countDown > 0)
        {
            //Debug.Log(countDown);
            return NodeStatus.RUNNING;
        }
        else if (countDown <= 0)
        {
            return NodeStatus.SUCCESS;

        }
        return NodeStatus.FAILURE;
    }

    public override void OnReset()
    {
        countDown = time;
    }
}
