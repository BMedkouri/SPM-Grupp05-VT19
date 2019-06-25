//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/EnemyImmobilisedState")]
public class EnemyImmobilisedState : EnemyCombatState
{
    // Attributes
    [SerializeField] private float stunTimer;


    // Methods
    public override void Enter()
    {
        base.Enter();
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
