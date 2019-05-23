using UnityEngine;
/*
 * @author Anders Ragnar
 */
public class AttackPlayer : Leaf
{
    private float attackTimer, countDown;
    public AttackPlayer(float attackTimer)
    {
        this.attackTimer = attackTimer;
    }
    /// <summary>
    /// This is one of the states that has some failsafes that you might think is "unnecessary"
    /// but we don't want the enemies to continue to attack if the player is dead or if he runs away (might be something we change)
    /// Here maybe the timer should be seperate aswell. the Object oriented hasn't realy come in yet.
    /// </summary>
    /// <param name="state"></param>
    /// <returns></returns>
    public override NodeStatus OnBehave(BehaviourState state)
    {
        
        if (Player.PlayerReference == null)
            return NodeStatus.FAILURE;
        
        if (!enemy.CanSeePlayer())
            return NodeStatus.FAILURE;
        if (Vector3.Distance(enemy.transform.position, Player.PlayerReference.transform.position) > enemy.AttackRange)
            return NodeStatus.FAILURE;

        enemy.RotateToTarget(Player.PlayerReference.transform.position);

        //här ska enemys attack spelas upp
        if (Vector3.Distance(enemy.transform.position, Player.PlayerReference.transform.position) < enemy.AttackRange && attackTimer <= 0)
        {
            enemy.Animator.SetTrigger("Attack");
            return NodeStatus.SUCCESS;
        }
        attackTimer -= Time.deltaTime;
        return NodeStatus.RUNNING;
    }


    public override void OnReset()
    {
        countDown = attackTimer;
    }
}
