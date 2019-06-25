//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

using UnityEngine;

// TODO: Rework this once we get the new enemy in place

[CreateAssetMenu(menuName = "Enemy States/EnemyAttackState")]
public class EnemyAttackState : EnemyCombatState
{
    // Attributes
    [SerializeField] private float attackDamage;
    private float clipTimer;

    // Methods
    public override void Enter()
    {
        clipTimer = 1f;
        base.Enter();
    }

    public override void HandleUpdate()
    {
        if (clipTimer <= 0)
        {
            owner.Transition<EnemyCombatState>();
        }

        clipTimer -= Time.deltaTime;
    }
}
