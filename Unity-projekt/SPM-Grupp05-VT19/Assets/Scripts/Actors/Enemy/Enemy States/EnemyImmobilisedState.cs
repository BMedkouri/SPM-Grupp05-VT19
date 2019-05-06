using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/EnemyImmobilisedState")]
public class EnemyImmobilisedState : EnemyCombatState
{
    [SerializeField] private float stunTimer;
    
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enter Immobilised");
    }

    public override void HandleUpdate()
    {
        if (stunTimer <= 0)
        {
            owner.Transition<EnemyCombatState>();
        }

        stunTimer -= Time.deltaTime;
    }
}
