using UnityEngine;
/*
 * @author Anders Ragnar
 */
public class AttackPlayer : Leaf
{
    private string[] attack;
    int index;
    private float countdown;
    private bool animationPlayed;
    public AttackPlayer(string[] attack)
    {
        this.attack = attack;
    }
    /// <summary>
    /// This class attack the player with diffrent animations if
    /// the enemy has more then one attackanimation.
    /// </summary>
    /// <param name="state">Is the refference to our enemy</param>
    /// <returns>Success if the animation is done, otherwise Running</returns>
    public override NodeStatus OnBehave(BehaviourState state)
    {
        
        //här ska enemys attack spelas upp
        if (animationPlayed == false && Vector3.Distance(enemy.transform.position, Player.PlayerReference.transform.position) < enemy.AttackRange)
        {
            Debug.Log("Attacks Player");
            animationPlayed = true;
            if (enemy is BossBehaviourTree==false)
            {
                index = 0;
                countdown = 0.75f;
            }
            else
            {
                countdown = enemy.GetComponent<BossBehaviourTree>().Attacktimes[attack[index]];
            }
            Debug.Log(attack[index]);
            enemy.Animator.SetTrigger(attack[index]);
        }
        countdown -= Time.deltaTime;
        if(countdown <= 0)
        {
            return NodeStatus.SUCCESS;
        }
        else
        {
            return NodeStatus.RUNNING;
        }
    }

    public override void OnReset()
    {
        index = (index + 1) % attack.Length;
        animationPlayed = false;
    }
}
