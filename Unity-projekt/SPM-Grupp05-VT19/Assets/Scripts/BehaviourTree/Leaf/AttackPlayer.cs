using UnityEngine;
/*
 * @author Anders Ragnar
 */
public class AttackPlayer : Leaf
{
    private string[] attack;
    int index;
    private float attackTimer, countDown;
    private float count;
    public AttackPlayer(float attackTimer, string[] attack)
    {
        this.attackTimer = attackTimer;
        this.attack = attack;
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
        if (Vector3.Distance(enemy.transform.position, Player.PlayerReference.transform.position) < enemy.AttackRange && countDown <= 0)
        {
            //Debug.Log(countDown);
            countDown = attackTimer;
            if (enemy is BossBehaviourTree==false)
            {
                index = 0;
            }
            enemy.Animator.SetTrigger(attack[index]);
            return NodeStatus.SUCCESS;
        }
        count += Time.deltaTime;
        countDown -= Time.deltaTime;
        return NodeStatus.RUNNING;
    }

    public override void OnReset()
    {
        index = (index + 1) % attack.Length;
    }
}
