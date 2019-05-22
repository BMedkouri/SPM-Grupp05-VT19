using UnityEngine;
/*
 * @author Anders Ragnar
 */

/// <summary>
/// should be a timer that is for all other behaviours aswell.
/// the timer should be set in the constructor and not be hardcoded like this.
/// </summary>
public class Timer : Leaf
{
    private float timer;
    
    public override NodeStatus OnBehave(BehaviourState state)
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);
        if(timer > 0)
        {
            return NodeStatus.RUNNING;
        }
        else
        {
            return NodeStatus.SUCCESS;

        }
    }

    public override void OnReset()
    {
        timer = 3f;
    }
}
