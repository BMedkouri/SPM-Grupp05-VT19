using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Anders Ragnar
 */
[CreateAssetMenu(menuName = "Player States/PlayerHealState")]
public class PlayerHealState : PlayerBaseState
{
    [SerializeField] private float healCastDuration, healAmount;
    private float timer;
    public override void Enter()
    {
        base.Enter();
        timer = healCastDuration;
    }
    /// <summary>
    /// Stays in the state until the timer is finished
    /// </summary>
    public override void HandleUpdate()
    {
        if (timer <= 0)
        {
            owner.GetComponent<HealthComponent>().RecoverHealth(healAmount);
            owner.Transition<OnGroundState>();
        }
        timer -= Time.deltaTime;
    }
}
