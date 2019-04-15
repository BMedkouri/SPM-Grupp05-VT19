using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerLightState")]
public class PlayerLightState : OnGroundState
{
    [SerializeField] private float attackDamage;
    [SerializeField] private float energyExpenditure; // Energy cost

    private Animator anim;
    private SphereCollider collider;
    private float clipTimer;
    private GameObject lightChild, Cross;
    AttackCollisionDetection attackCollisionDetection;
    AnimatorClipInfo[] animClip;
    [SerializeField] private LayerMask lightAttackMask;



    public override void Enter()
    {
        base.Enter();

        if(owner.GetCurrentEnergy() < energyExpenditure)
        {
            owner.Transition<OnGroundState>();
        }
        else
        {
            owner.LoseEnergy(energyExpenditure);
            lightChild = GameObject.FindGameObjectWithTag("LightAttack");
            Cross = GameObject.FindGameObjectWithTag("Cross");
            collider = lightChild.GetComponent<SphereCollider>();

            attackCollisionDetection = lightChild.GetComponent<AttackCollisionDetection>();
            attackCollisionDetection.InitializeOldPosition();

            anim = Cross.GetComponentInChildren<Animator>();

            anim.Play("PlayerLightAnimation");

            animClip = this.anim.GetCurrentAnimatorClipInfo(0);

            clipTimer = 1f;
            //clipTimer = animClip[0].clip.length;
        }
    }
    public override void HandleUpdate()
    {

        if (collider.enabled)
        {
           // Physics.OverlapSphere(owner.transform.position, collider.radius, lightAttackMask);
            Debug.Log("Enable");
            
            //attackCollisionDetection.RunCollisionDetection();

            //if (attackCollisionDetection.GetHitInfo().collider != null)
            //{
            //    Debug.Log("hit");
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
            if (owner.collision.IsGrounded())
            {
                owner.Transition<OnGroundState>();
            }
            else
            {
                owner.Transition<InAirState>();
            }
        }
        countDown();
    }
    public void countDown()
    {
        clipTimer -= Time.deltaTime;
    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("HIT");
        Debug.Log(col.gameObject.name);
        if(col.gameObject.name == "Enemy")
        {
            Debug.Log("hit");
            Enemy enemy = attackCollisionDetection.GetEnemy();

            Debug.Log("Enemy health before attack: " + enemy.GetCurrentHealth());
            enemy.TakeDamage(attackDamage);
            Debug.Log("Enemy health after attack: " + enemy.GetCurrentHealth());
        }
    }

}
