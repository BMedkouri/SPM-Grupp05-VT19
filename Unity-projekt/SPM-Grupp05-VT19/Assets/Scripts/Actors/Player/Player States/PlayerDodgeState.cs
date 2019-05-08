using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerDodgeState")]
public class PlayerDodgeState : OnGroundState
{
    [SerializeField] private float dodgeTimer;
    [SerializeField] private float dodgeSpeed;
    [SerializeField] private float staminaExpenditure; // Stamina cost
    private float clipTimer;
    AnimatorClipInfo[] animClip;


    private float countDown;
    //Vector3 oldVelocity;
    public override void Enter()
    {
        base.Enter();

        if(owner.GetCurrentStamina() < staminaExpenditure)
        {
            owner.Transition<OnGroundState>();
        }
        else
        {
            owner.LoseStamina(staminaExpenditure);

            //Debug.Log(dodgeTimer);
            //Debug.Log("Enter DodgeState");
            //oldVelocity = owner.physics.GetVelocity();

            owner.physics.AddVelocity(dodgeSpeed * owner.physics.GetDirection());
            owner.anim.SetTrigger("Dodge");
            animClip = owner.anim.GetCurrentAnimatorClipInfo(0);
            countDown = dodgeTimer;
        }
    }
    public override void HandleUpdate()
    {
        if (countDown <= 0)
        {
            //Debug.Log("dodgetimer < 0");
            //owner.physics.SetVelocity(oldVelocity);
            owner.Transition<OnGroundState>();
        }
        CountDown();
    }
    public void CountDown()
    {
        
        countDown -= Time.deltaTime;
    }
}
