using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerHealState")]
public class PlayerHealState : PlayerBaseState
{
    [SerializeField] private float healTimer , increaseHealth;
    private float timer;
    private float healthWhenStartedState;
    public override void Enter()
    {
        base.Enter();
        timer = healTimer;
        //healthWhenStartedState = owner.GetCurrentHealth();
    }
    public override void HandleUpdate()
    {
        //if(owner.GetCurrentHealth() < healthWhenStartedState)
        //{
        //    owner.Transition<OnGroundState>();
        //}
        //if(timer <= 0)
        //{
        //    owner.RecoverHealth(increaseHealth);
        //    owner.Transition<OnGroundState>();
        //}
        countdown();
    }
    private void countdown()
    {
        timer -= Time.deltaTime;
    }
}
