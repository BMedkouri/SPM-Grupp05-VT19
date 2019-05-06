using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerParryState")]
public class PlayerParryState : OnGroundState
{
    [SerializeField] private float staminaExpenditure;  // Stamina cost

    private Animator anim;
    private float clipTimer;

    public override void Enter()
    {
        base.Enter();

        if (owner.GetCurrentStamina() < staminaExpenditure)
        {
            owner.Transition<OnGroundState>();
        }
        else
        {
            owner.LoseStamina(staminaExpenditure);

            anim = GameObject.FindGameObjectWithTag("Cross").GetComponent<Animator>();

            anim.Play("PlayerParryAnimation");
            clipTimer = anim.GetCurrentAnimatorClipInfo(0).Length;
        }
    }
    public override void HandleUpdate()
    {
        if (clipTimer <= 0)
        {
            clipTimer = anim.GetCurrentAnimatorClipInfo(0).Length;
            owner.Transition<OnGroundState>();
        }

        clipTimer -= Time.deltaTime;
    }
}
