using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public override void HandleUpdate()
    {
        if (timer <= 0)
        {
            owner.GetComponent<HealthComponent>().RecoverHealth(healAmount);
            owner.Transition<OnGroundState>();
        }
        countdown();
    }
    private void countdown()
    {
        timer -= Time.deltaTime;
    }
}
