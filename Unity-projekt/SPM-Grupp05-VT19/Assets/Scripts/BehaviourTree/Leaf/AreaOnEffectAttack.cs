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
        enemy.Animator.SetTrigger("DarkAoeAttack");
        //enemy = (BossBehaviourTree)behaviour.BehaviourTree;
        enemy.GetComponent<BossBehaviourTree>().StartResetBool();
        enemy.GetComponent<BossBehaviourTree>().CanDoDarkAttack = false;
        return NodeStatus.SUCCESS;
    }

    public override void OnReset()
    {
    }
    
}
