//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

using UnityEngine;

public class EnemyBaseState : State
{
    [Header("Movement Speed")]
    [SerializeField] protected float movementSpeed;

    protected Enemy owner;

    /// <summary>
    /// Sets the speed and the material.
    /// </summary>
    public override void Enter()
    {
        owner.Agent.speed = movementSpeed;
    }

    public override void Initialize(StateMachine owner)
    {
        this.owner = (Enemy)owner;
    }
}
