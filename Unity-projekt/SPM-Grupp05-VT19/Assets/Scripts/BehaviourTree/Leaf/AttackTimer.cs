using UnityEngine;

public class AttackTimer : Leaf
{
    private float time;
    private float countDown;
    public AttackTimer(float setTimer)
    {
        time = setTimer;
        //countDown = time;
    }

    public override NodeStatus OnBehave(BehaviourState state)
    {
        if (Player.Instance == null)
            return NodeStatus.FAILURE;
        if (!enemy.CanSeePlayer())
            return NodeStatus.FAILURE;
        if (Vector3.Distance(enemy.transform.position, Player.Instance.transform.position) > enemy.AttackRange)
            return NodeStatus.FAILURE;

        enemy.RotateToTarget(Player.Instance.transform.position);

        countDown -= Time.deltaTime;
        if (countDown > 0)
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
