using UnityEngine;
/*
 * @author Anders Ragnar
 */

public class CheckMyHealth : Leaf
{
    private float procentHealth;
    /// <summary>
    /// sets a procent
    /// </summary>
    /// <param name="health">how much procent</param>
    public CheckMyHealth(float health)
    {
        procentHealth = health;
    }
    /// <summary>
    /// checks the procent of the Enemies health
    /// </summary>
    /// <param name="state">Contanct with the Enemy</param>
    /// <returns>Success if it's under a procent of health</returns>
    public override NodeStatus OnBehave(BehaviourState state)
    {
        Debug.Log("CheckHealth");
        HealthComponent healthStatus = enemy.GetComponent<HealthComponent>();
        if(healthStatus.CurrentHealth/healthStatus.MaxHealth <= procentHealth)
        {
            //sätt variabeln till true
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
