/*
 * @author Anders Ragnar
 */

public class AreaOnEffectAttack : Leaf
{
    private float timer, countDown;
    /// <summary>
    /// takes a timer for the chargtime on the attack
    /// </summary>
    /// <param name="attackTimer">the timer</param>
    public AreaOnEffectAttack(float attackTimer)
    {
        timer = attackTimer;
    }
    /// <summary>
    /// This makes the attack, maybe we should have a seperate timer and this should only make the attack.
    /// </summary>
    /// <param name="state">The refference to the enemy</param>
    /// <returns>Success or Running, should be able to fail and should be able to come here on the fail reason</returns>
    public override NodeStatus OnBehave(BehaviourState state)
    {
        if(countDown < 0)
        {
            //sätt igång skadan här
            return NodeStatus.SUCCESS;
        }
        //uppladdning ska köras här
        return NodeStatus.RUNNING;
    }

    public override void OnReset()
    {
        countDown = timer;
    }
    
}
