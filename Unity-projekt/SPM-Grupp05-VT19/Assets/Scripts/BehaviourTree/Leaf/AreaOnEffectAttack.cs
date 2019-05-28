using System.Collections;
using UnityEngine;
/*
 * @author Anders Ragnar
 */

public class AreaOnEffectAttack : Leaf
{
    /// <summary>
    /// This makes the attack, maybe we should have a seperate timer and this should only make the attack.
    /// </summary>
    /// <param name="state">The refference to the enemy</param>
    /// <returns>Success or Running, should be able to fail and should be able to come here on the fail reason</returns>
    public override NodeStatus OnBehave(BehaviourState state)
    {
        if (enemy.CanDoDarkAttack)
        {
            enemy.GetComponent<BehaviourTree>().CanDoDarkAttack = false;
            enemy.GetComponent<BehaviourTree>().StartResetBool();
            enemy.Animator.SetTrigger("DarkAoeAttack");
            return NodeStatus.SUCCESS;
        }
        else
        {
            return NodeStatus.FAILURE;
        }
    }

    public override void OnReset()
    {
    }
    
}
