using System.Collections;
using UnityEngine;
/*
 * @author Anders Ragnar
 */

public class AreaOnEffectAttack : Leaf
{
    /// <summary>
    /// This class makes the dark attack, returning Success or Failiure, 
    /// maybe we should add Running when the enemy makes the attack animation
    /// </summary>
    /// <param name="state">The refference to the enemy</param>
    /// <returns>Success if the enemy can attack, Failiure if not</returns>
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
