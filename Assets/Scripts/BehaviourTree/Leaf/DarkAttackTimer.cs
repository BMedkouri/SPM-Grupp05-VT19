using UnityEngine;
/*
 * @author Anders Ragnar
 */

/// <summary>
/// this state is a timer for the dark attack
/// </summary>
public class DarkAttackTimer : Leaf
{
    private float time;
    private float countDown;
    public DarkAttackTimer(float setTimer)
    {
        time = setTimer;
        countDown = time;
    }
    public override NodeStatus OnBehave(BehaviourState state)
    {
        countDown -= Time.deltaTime;
        if (enemy.CanDoDarkAttack == false)
        {
            return NodeStatus.FAILURE;
        }
        else if (countDown > 0)
        {
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
