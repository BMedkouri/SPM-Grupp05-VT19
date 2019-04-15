using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/AttackState")]
public class AttackState : PlayerBaseState
{
    // Attributes
    [SerializeField] private float attackDamage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float staminaExpenditure;
    private float attackTimer;

    //Attack
    private AttackCollisionDetection attackCollisionDetection;
    private Animator animator;

    // Methods
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

            //Attack
            attackCollisionDetection = GameObject.FindGameObjectWithTag("PlayerWeapon").GetComponent<AttackCollisionDetection>();
            attackCollisionDetection.InitializeOldPosition();

            attackTimer = attackSpeed;

            //Plays animation
            animator = GameObject.FindGameObjectWithTag("PlayerWeapon").GetComponentInParent<Animator>();
            animator.Play("PlayerAttackAnimation");
            //Se AnimatorClipInfo för lösning
            //animator.SetFloat("playerAttackSpeed", animator.GetCurrentAnimatorClipInfo(0).Length / attackSpeed);

        }

    }

    public override void HandleUpdate()
    {
        attackCollisionDetection.RunCollisionDetection();

        if(attackCollisionDetection.GetHitInfo().collider != null)
        {
            Debug.Log("Enemy health before attack: " + attackCollisionDetection.GetEnemy().GetCurrentHealth());
            attackCollisionDetection.GetEnemy().TakeDamage(attackDamage);
            Debug.Log("Enemy health after attack: " + attackCollisionDetection.GetEnemy().GetCurrentHealth());

            //Add knockback later
            //enemy.physics.AddVelocity();
        }

        if (attackTimer <= 0)
        {
            if (owner.collision.IsGrounded())
            {
                owner.Transition<OnGroundState>();
            }
            else
            {
                owner.Transition<InAirState>();
            }
        }

        attackTimer -= Time.deltaTime;

        base.HandleUpdate();
    }
}
