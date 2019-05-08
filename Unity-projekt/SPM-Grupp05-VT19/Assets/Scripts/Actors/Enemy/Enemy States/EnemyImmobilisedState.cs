using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @author Anders Ragnar
 * 
 * This is the scripts that the enemy/object is in when it's attack gets parried.
 */ 
[CreateAssetMenu(menuName = "Enemy States/EnemyImmobilisedState")]
public class EnemyImmobilisedState : EnemyCombatState
{
    [SerializeField] private float stunTimer;
    
    public override void Enter()
    {
        base.Enter();
    }

    /// <summary>
    /// This counts down the time the enemy/object should be stunned.
    /// </summary>
    public override void HandleUpdate()
    {
        if (stunTimer <= 0)
        {
            owner.Transition<EnemyCombatState>();
        }

        stunTimer -= Time.deltaTime;
    }
}
