using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerParryState")]
public class PlayerParryState : OnGroundState
{
    [SerializeField] private float attackDamage;
    [SerializeField] private float staminaExpenditure;  // Stamina cost

    private Animator anim;
    private float clipTimer;
    private GameObject cross, parry;
    BoxAttackController attackCollisionDetection;
    BoxCollider box;

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

            cross = GameObject.FindGameObjectWithTag("Cross");
            parry = GameObject.FindGameObjectWithTag("Parry");
            box = parry.GetComponent<BoxCollider>();
            anim = cross.GetComponentInChildren<Animator>();
            anim.Play("PlayerParryAnimation");
            clipTimer = anim.GetCurrentAnimatorClipInfo(0).Length;
            attackCollisionDetection = parry.GetComponent<BoxAttackController>();
        }
    }
    public override void HandleUpdate()
    {
        if (box.enabled)
        {
            //attackCollisionDetection.RunCollisionDetection();

            //if (attackCollisionDetection.GetHitInfo().collider != null)
            //{
            //    Enemy enemy = attackCollisionDetection.GetEnemy();

            //    Debug.Log("Enemy health before attack: " + enemy.GetCurrentHealth());
            //    enemy.TakeDamage(attackDamage);
            //    Debug.Log("Enemy health after attack: " + enemy.GetCurrentHealth());

            //    //Add knockback later
            //    //enemy.physics.AddVelocity();
            //}
        }
       
        if (clipTimer <= 0)
        {
            Debug.Log("if");
            clipTimer = anim.GetCurrentAnimatorClipInfo(0).Length;
            Debug.Log(clipTimer);
            owner.Transition<OnGroundState>();
        }
        countDown();
    }
    public void countDown()
    {
        clipTimer -= Time.deltaTime;
    }
}
